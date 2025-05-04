using CureX.Application.Contracts;
using CureX.Application.DTO;
using CureX.Domain.Models;
using CureX.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Globalization;
using System.IO;
using System.Numerics;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Document = QuestPDF.Fluent.Document;

namespace CureX.Application.Services
{
    public class BillingService : IBillingService
    {
        private readonly CureXDbContext _context;
        private readonly string _invoiceDirectory = "wwwroot/invo";

        public BillingService(CureXDbContext context)
        {
            _context = context;
            if (!Directory.Exists(_invoiceDirectory))
                Directory.CreateDirectory(_invoiceDirectory);
        }

        public async Task<BillDto> GenerateBillAsync(string patientContact, int appointmentId)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Contact == patientContact);
            if (patient == null)
                throw new ArgumentException("Patient not found.");

            var appointment = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == appointmentId);
            if (appointment == null)
                throw new ArgumentException("Appointment not found.");

            var bill = new Bill
            {
                PatientId = patient.Id,
                AppointmentId = appointment.Id,
                Amount = appointment.Amount,
                GeneratedAt = DateTime.UtcNow,
                Status = "Pending",
                 InvoicePath = "/invoices/temp.pdf"
            };

            // You don't need to assign Patient or Appointment directly
            _context.Bills.Add(bill);
            await _context.SaveChangesAsync();

            // Generate PDF and save to file system
            var fileName = $"Invoice_{bill.BillId}_{DateTime.UtcNow.Ticks}.pdf";
            var filePath = Path.Combine(_invoiceDirectory, fileName);

            GeneratePdfInvoice(bill, patient, filePath);

            // Save the invoice path in the database
            bill.InvoicePath = fileName;
            await _context.SaveChangesAsync();

            return new BillDto
            {
                BillId = bill.BillId,
                PatientName = patient.FullName,
                AppointmentDate = appointment.AppointmentDate,
                Amount = bill.Amount,
                Status = bill.Status,
                GeneratedAt = bill.GeneratedAt
            };
        }

        private void GeneratePdfInvoice(Bill bill, Patient patient, string filePath)
        {
            var culture = new CultureInfo("en-US");

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(50);
                    page.Size(PageSizes.A4);

                    // Header
                    page.Header()
                        .Row(row =>
                        {
                            row.RelativeItem().Column(column =>
                            {
                                column.Item().Text("CureX").FontSize(20).FontFamily("Arial").Bold();
                                column.Item().Text("Address: Mansoura").FontFamily("Arial");
                            });

                            row.RelativeItem().AlignRight().Column(column =>
                            {
                                column.Item().Text("INVOICE").FontSize(20).FontFamily("Arial").Bold();
                                column.Item().Text($"Invoice No: {bill.BillId}").FontFamily("Arial");
                            });
                        });

                    // Content
                    page.Content()
                        .PaddingVertical(20)
                        .Column(column =>
                        {
                            // Bill To and Date
                            column.Item().Row(row =>
                            {
                                row.RelativeItem().Column(c =>
                                {
                                    c.Item().Text("Bill To:").Bold();
                                    c.Item().Text(patient.FullName).FontFamily("Arial").FontSize(14);
                                    c.Item().Text(patient.Address).FontFamily("Arial").FontSize(12);
                                });

                                row.RelativeItem().AlignRight().Column(c =>
                                {
                                    c.Item().Text($"Invoice #: {bill.BillId}").Bold();
                                    c.Item().Text($"Date: {bill.GeneratedAt.ToString("dd/MM/yyyy", culture)}");
                                });
                            });

                            column.Item().PaddingVertical(10).LineHorizontal(1);

                            // Table
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(40);    // #
                                    columns.RelativeColumn();      // Description
                                    columns.ConstantColumn(60);    // Tax
                                    columns.ConstantColumn(80);    // Amount
                                });

                                // Table Header
                                table.Header(header =>
                                {
                                    header.Cell().Element(CellStyle).Text("#").Bold();
                                    header.Cell().Element(CellStyle).Text("Description").Bold();
                                    header.Cell().Element(CellStyle).AlignRight().Text("Tax").Bold();
                                    header.Cell().Element(CellStyle).AlignRight().Text("Total").Bold();
                                });

                                // Table Body (Example row)
                                table.Cell().Element(CellStyle).Text("1");
                                table.Cell().Element(CellStyle).Text("Consultation Fee");
                                table.Cell().Element(CellStyle).AlignRight().Text("0.00");
                                table.Cell().Element(CellStyle).AlignRight().Text(bill.Amount.ToString("C", culture));
                            });

                            // Total
                            column.Item().AlignRight().PaddingTop(15).Column(total =>
                            {
                                total.Item().Text($"Total: {bill.Amount.ToString("C", culture)}").FontSize(14).Bold();
                            });
                        });

                    // Footer
                    page.Footer()
                        .AlignCenter()
                        .Text(text =>
                        {
                            text.Line("Thank you for choosing CureX.").FontSize(12);
                            text.Line("For questions, contact support@curex.com").FontSize(10);
                        });
                });
            });

            document.GeneratePdf(filePath);

            // Local function for table cell style
            IContainer CellStyle(IContainer container) =>
                container.PaddingVertical(5).PaddingHorizontal(5);
        }


        public async Task<byte[]> GenerateBillPdfAsync(int billId)
        {
            var bill = await _context.Bills.Include(b => b.Patient).Include(b => b.Appointment)
                .FirstOrDefaultAsync(b => b.BillId == billId);
            if (bill == null)
                throw new ArgumentException("Bill not found.");

            var filePath = Path.Combine(_invoiceDirectory, bill.InvoicePath);

            if (!File.Exists(filePath))
                throw new FileNotFoundException("Invoice PDF not found.");

            return await File.ReadAllBytesAsync(filePath);
        }

        public async Task<List<BillDto>> GetBillsByPatientAsync(string patientContact)
        {
            var bills = await _context.Bills.Include(b => b.Patient).Include(b => b.Appointment)
                .Where(b => b.Patient.Contact == patientContact)
                .ToListAsync();

            return bills.Select(b => new BillDto
            {
                BillId = b.BillId,
                PatientName = b.Patient.FullName,
                AppointmentDate = b.Appointment.AppointmentDate,
                Amount = b.Amount,
                Status = b.Status,
                GeneratedAt = b.GeneratedAt
            }).ToList();
        }

        public async Task<MonthlyReportDto> GetMonthlyBillingReportAsync(int year, int month)
        {
            var bills = await _context.Bills
                .Where(b => b.GeneratedAt.Year == year && b.GeneratedAt.Month == month)
                .ToListAsync();

            var totalBills = bills.Count;
            var totalRevenue = bills.Sum(b => b.Amount);
            var paidBills = bills.Count(b => b.Status == "Paid");
            var pendingBills = totalBills - paidBills;

            return new MonthlyReportDto
            {
                Year = year,
                Month = month,
                TotalBills = totalBills,
                TotalRevenue = totalRevenue,
                PaidBills = paidBills,
                PendingBills = pendingBills
            };
        }

        public async Task<List<BillAnalysisDto>> GetBillingAnalyticsAsync(DateTime from, DateTime to)
        {
            var bills = await _context.Bills
                .Where(b => b.GeneratedAt >= from && b.GeneratedAt <= to)
                .GroupBy(b => b.Status)
                .Select(g => new BillAnalysisDto
                {
                    Category = g.Key,
                    Count = g.Count(),
                    TotalAmount = g.Sum(b => b.Amount)
                })
                .ToListAsync();

            return bills;
        }
    }
}

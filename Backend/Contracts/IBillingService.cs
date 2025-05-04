using CureX.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CureX.Application.Contracts
{
    public interface IBillingService
    {
        Task<BillDto> GenerateBillAsync(string patientContact, int appointmentId);
        Task<byte[]> GenerateBillPdfAsync(int billId); 
        Task<List<BillDto>> GetBillsByPatientAsync(string patientContact);
        Task<MonthlyReportDto> GetMonthlyBillingReportAsync(int year, int month);
        Task<List<BillAnalysisDto>> GetBillingAnalyticsAsync(DateTime from, DateTime to);
    }

}

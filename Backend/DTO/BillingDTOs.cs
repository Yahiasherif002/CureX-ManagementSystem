using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CureX.Application.DTO
{
    public class BillDto
    {
        public int BillId { get; set; }
        public string PatientName { get; set; } = "";
        public DateTime AppointmentDate { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } = "";
        public DateTime GeneratedAt { get; set; }
        public string InvoiceUrl { get; set; } = ""; // Add this
    }


    public class MonthlyReportDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int TotalBills { get; set; }
        public decimal TotalRevenue { get; set; }
        public int PaidBills { get; set; }
        public int PendingBills { get; set; }
    }

    public class BillAnalysisDto
    {
        public string Category { get; set; } 
        public int Count { get; set; }
        public decimal TotalAmount { get; set; }
    }

}

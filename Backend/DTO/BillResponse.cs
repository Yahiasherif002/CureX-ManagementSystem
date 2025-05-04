using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.DTO
{
    public class BillResponse
    {
        public int BillId { get; set; }
        public string PatientName { get; set; }
        public string PatientContact { get; set; }
        public DateTime IssuedDate { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public string InvoiceNumber { get; set; }
        public string ErrorMessage { get; set; }  
    }
}

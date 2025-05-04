namespace CureX.Domain.Models
{
    public class Bill
    {
        public int BillId { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } 
        public DateTime GeneratedAt { get; set; }
        public string InvoicePath { get; set; } 
    }
}
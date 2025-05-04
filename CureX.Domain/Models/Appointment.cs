namespace CureX.Domain.Models;


public class Appointment
{
    public int Id { get; set; }
    public DateTime AppointmentDate { get; set; }
    public Patient Patient { get; set; }
    public User Doctor { get; set; }
    public decimal Amount { get; set; } = 0.0m; 

    public string PatientContact { get; set; } = ""; 
    public string DoctorUsername { get; set; } = ""; 
    public string Status { get; set; } = "Pending"; 
    public string ServiceDescription { get; set; } = ""; 

}


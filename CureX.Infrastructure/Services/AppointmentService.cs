using Backend.Models.DTO;
using CureX.Application.Contracts;
using CureX.Domain.Models;
using CureX.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class AppointmentService:IAppointmentService
{
    private readonly CureXDbContext _context;

    public AppointmentService(CureXDbContext context)
    {
        _context = context;
    }

    public Task<bool> CancelAppointmentAsync(int appointmentId)
    {
        var appointment = _context.Appointments
            .FirstOrDefaultAsync(a => a.Id == appointmentId);

        if (appointment == null)
        {
            return Task.FromResult(false);
        }

        var appointmentResult = appointment.Result;

        if (appointmentResult == null)
        {
            return Task.FromResult(false);
        }

        appointmentResult.Status = "Cancelled";
        _context.SaveChangesAsync();
        return Task.FromResult(true);
    }

    // Create an appointment
    public async Task<AppointmentResponse> CreateAppointmentAsync(CreateAppointmentRequest request)
    {
        var patient = await _context.Patients
            .FirstOrDefaultAsync(p => p.Contact == request.PatientContact);

        if (patient == null)
        {
            throw new ArgumentException("Patient not found with the provided contact.");
        }

        var doctor = await _context.Users
            .FirstOrDefaultAsync(u => u.Role == "Doctor");

        if (doctor == null)
        {
            throw new ArgumentException("Doctor not found in the system.");
        }

        var appointment = new Appointment()
        {
            AppointmentDate = DateTime.UtcNow,
            Amount = request.Amount,
            Patient = patient, 
            Doctor = doctor,   
            Status = "Scheduled",
            ServiceDescription = request.ServiceDescription
        };

        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();

        return new AppointmentResponse
        {
           AppointmentId  = appointment.Id,
            AppointmentDate = appointment.AppointmentDate,
            PatientName = patient.FullName,
            Amount=appointment.Amount,
            ServiceDescription = request.ServiceDescription,
            Status = appointment.Status
        };
    }

    public Task<AppointmentResponse> GetAppointmentByIdAsync(int appointmentId)
    {
        var appointment = _context.Appointments
            .Include(a => a.Patient)
            .FirstOrDefaultAsync(a => a.Id == appointmentId);
        if (appointment == null)
        {
            return Task.FromResult<AppointmentResponse>(null);
        }
        var appointmentResult = appointment.Result;
        return Task.FromResult(new AppointmentResponse
        {
            PatientName = appointmentResult.Patient.FullName,
            PatientContact = appointmentResult.PatientContact,
            AppointmentDate = appointmentResult.AppointmentDate,
            Status = appointmentResult.Status
        });
    }

    // Get appointments by patient contact or all appointments if no filter is provided
    public async Task<List<AppointmentResponse>> GetAppointmentsAsync(string patientContact = null)
    {
        var query = _context.Appointments
            .Include(a => a.Patient)
            .AsQueryable();

        if (!string.IsNullOrEmpty(patientContact))
        {
            query = query.Where(a => a.PatientContact == patientContact);
        }

        return await query
            .Select(a => new AppointmentResponse
            {
                PatientName = a.Patient.FullName, 
                PatientContact = a.PatientContact,
                AppointmentDate = a.AppointmentDate,
                Status = a.Status
            })
            .ToListAsync();
    }

    public async Task<List<AppointmentResponse>> GetTodayAppointmentsAsync()
    {
        DateTime today = DateTime.Today;

        return await _context.Appointments
            .Include(a => a.Patient)
            .Where(a => a.AppointmentDate.Date == today)
            .Select(a => new AppointmentResponse
            {
                PatientName = a.Patient.FullName,
                PatientContact = a.PatientContact,
                AppointmentDate = a.AppointmentDate,
                Status = a.Status
            })
            .ToListAsync();
    }
    public async Task<bool> UpdateAppointmentStatusAsync(string patientContact, string newStatus)
    {
        var appointment = await _context.Appointments
            .FirstOrDefaultAsync(a => a.PatientContact == patientContact );

        if (appointment == null)
            return false;

        appointment.Status = newStatus;
        await _context.SaveChangesAsync();
        return true;
    }

    
}

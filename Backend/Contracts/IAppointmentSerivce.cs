using Backend.Models.DTO;
using CureX.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CureX.Application.Contracts
{     public interface IAppointmentService
        {
            Task<AppointmentResponse> CreateAppointmentAsync(CreateAppointmentRequest request);
            Task<List<AppointmentResponse>> GetAppointmentsAsync(string patientContact = null);
            Task<List<AppointmentResponse>> GetTodayAppointmentsAsync();
            Task<bool> UpdateAppointmentStatusAsync(string patientContact, string newStatus);
            Task<AppointmentResponse> GetAppointmentByIdAsync(int appointmentId);
            Task<bool> CancelAppointmentAsync(int appointmentId);
        }

    
}

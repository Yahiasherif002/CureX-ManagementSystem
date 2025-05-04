using CureX.Backend.DTO;

using CureX.Services;
using Microsoft.AspNetCore.Mvc;
using Backend.Models.DTO;
using CureX.Application.Contracts;

namespace CureX.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        /// <summary>
        /// Create a new appointment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentRequest request)
        {
            try
            {
                var appointment = await _appointmentService.CreateAppointmentAsync(request);
                return CreatedAtAction(nameof(GetAppointments), new { id = appointment.AppointmentId }, appointment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        /// <summary>
        /// Get all appointments for a specific patient or all appointments if no contact is provided.
        /// </summary>
        /// <param name="patientContact"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAppointments([FromQuery] string patientContact = null)
        {
            try
            {
                var appointments = await _appointmentService.GetAppointmentsAsync(patientContact);
                if (appointments == null || appointments.Count == 0)
                {
                    return NotFound("No appointments found.");
                }
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        /// <summary>
        /// Update the status of an appointment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("update-status")]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateStatusRequest request)
        {
            var success = await _appointmentService.UpdateAppointmentStatusAsync(
                request.PatientContact,
                request.Status);

            if (!success)
                return NotFound("Appointment not found.");

            return Ok("Status updated.");
        }

        /// <summary>
        /// Get a specific appointment by ID.
        /// </summary>
        /// <returns></returns>
        [HttpGet("today")]
        public async Task<IActionResult> GetTodayAppointments()
        {
            var appointments = await _appointmentService.GetTodayAppointmentsAsync();
            return Ok(appointments);
        }

    }
}

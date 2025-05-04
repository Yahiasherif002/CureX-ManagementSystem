using CureX.Application.Contracts;
using CureX.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CureX.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillingService _billingService;

        public BillController(IBillingService billingService)
        {
            _billingService = billingService;
        }
        /// <summary>
        /// Generate a bill for a specific patient and appointment.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        [HttpPost("Generate")]
        public async Task<IActionResult> GenerateBillAsync([FromBody] GenerateBillRequest request)
        {
            // Example: request contains patient contact and appointment ID
            if (string.IsNullOrEmpty(request.PatientContact) || request.AppointmentId <= 0)
                return BadRequest("Invalid input.");

            try
            {
                var bill = await _billingService.GenerateBillAsync(request.PatientContact, request.AppointmentId);
                return Ok(bill); // Return BillDto
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
        /// <summary>
        /// Get a PDF of the bill for a specific bill ID.
        /// </summary>
        /// <param name="billId"></param>
        /// <returns></returns>

        [HttpGet("Pdf/{billId}")]
        public async Task<IActionResult> GetBillPdfAsync(int billId)
        {
            try
            {
                var pdfBytes = await _billingService.GenerateBillPdfAsync(billId);
                return File(pdfBytes, "application/pdf", $"Invoice_{billId}.pdf");
            }
            catch (Exception ex)
            {
                return NotFound($"Error: {ex.Message}");
            }
        }
        /// <summary>
        /// Get all bills for a specific patient.
        /// </summary>
        /// <param name="patientContact"></param>
        /// <returns></returns>

        [HttpGet("Patient/{patientContact}")]
        public async Task<IActionResult> GetBillsByPatientAsync(string patientContact)
        {
            try
            {
                var bills = await _billingService.GetBillsByPatientAsync(patientContact);
                return Ok(bills);
            }
            catch (Exception ex)
            {
                return NotFound($"Error: {ex.Message}");
            }
        }
        /// <summary>
        /// Get monthly billing report for a specific year and month.
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>

        [HttpGet("Report/{year}/{month}")]
        public async Task<IActionResult> GetMonthlyBillingReportAsync(int year, int month)
        {
            try
            {
                var report = await _billingService.GetMonthlyBillingReportAsync(year, month);
                return Ok(report);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
        /// <summary>
        /// Get billing analytics for a specific date range.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        [HttpGet("Analytics/{from}/{to}")]
        public async Task<IActionResult> GetBillingAnalyticsAsync(DateTime from, DateTime to)
        {
            try
            {
                var analytics = await _billingService.GetBillingAnalyticsAsync(from, to);
                return Ok(analytics);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }

    public class GenerateBillRequest
    {
        public string PatientContact { get; set; }
        public int AppointmentId { get; set; }
    }
}

using CureX.Application.Contracts;
using CureX.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CureX.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        /// <summary>
        /// Get all patients.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetAllPatients()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            return Ok(patients);
        }

        /// <summary>
        /// Get a specific patient by contact number.
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [HttpGet("{contact}")]
        public async Task<ActionResult<Patient>> GetPatient(string contact)
        {
            var patient = await _patientService.GetPatientByContactAsync(contact);
            if (patient == null)
                return NotFound($"No patient found with contact: {contact}");

            return Ok(patient);
        }

        /// <summary>
        /// Register a new patient.
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Patient>> RegisterPatient([FromBody] Patient patient)
        {
            var created = await _patientService.RegisterPatientAsync(patient);
            return CreatedAtAction(nameof(GetPatient), new { contact = created.Contact }, created);
        }
        /// <summary>
        /// Update an existing patient by contact number.
        /// </summary>
        /// <param name="contact"></param>
        /// <param name="updatedPatient"></param>
        /// <returns></returns>

        [HttpPut("{contact}")]
        public async Task<IActionResult> UpdatePatient(string contact, [FromBody] Patient updatedPatient)
        {
            var success = await _patientService.UpdatePatientAsync(contact, updatedPatient);
            if (!success)
                return NotFound($"Patient with contact '{contact}' not found.");

            return NoContent();
        }

        /// <summary>
        /// Delete a patient by contact number.
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [HttpDelete("{contact}")]
        public async Task<IActionResult> DeletePatient(string contact)
        {
            var success = await _patientService.DeletePatientAsync(contact);
            if (!success)
                return NotFound($"Patient with contact '{contact}' not found.");

            return NoContent();
        }
    }
}

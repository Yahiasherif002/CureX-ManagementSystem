using CureX.Application.Contracts;
using CureX.Domain.Models;
using CureX.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CureX.Services
{
    public class PatientService : IPatientService
    {
        private readonly CureXDbContext _context;

        public PatientService(CureXDbContext context)
        {
            _context = context;
        }

        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            return await _context.Patients.ToListAsync(); 
        }

        public async Task<Patient> RegisterPatientAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient); 
            await _context.SaveChangesAsync(); 
            return patient;
        }

        public async Task<Patient> GetPatientByContactAsync(string contact)
        {
            return await _context.Patients.FirstOrDefaultAsync(p => p.Contact == contact); 
        }

      
            public async Task<bool> UpdatePatientAsync(string contact, Patient dto)
            {
            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Contact == contact);
            if (patient == null)
            {
                return false;
            }

            
                  patient.FullName = dto.FullName;
                  patient.Age = dto.Age;
                  patient.Gender = dto.Gender;
                  patient.Address = dto.Address;
                  patient.Email = dto.Email;
                  patient.MedicalHistory = dto.MedicalHistory;

            await _context.SaveChangesAsync();
            return true;
            }


        

       public async Task<bool>  DeletePatientAsync(string contact)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Contact == contact);
            if (patient == null)
            {
                return false; 
            }
            _context.Patients.Remove(patient); 
            await _context.SaveChangesAsync(); 
            return true;
        }
    }
}

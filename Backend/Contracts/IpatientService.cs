using CureX.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CureX.Application.Contracts
{
    public interface IPatientService
    {
        Task<Patient> RegisterPatientAsync(Patient dto);
        Task<Patient> GetPatientByContactAsync(string contact);
        Task<List<Patient>> GetAllPatientsAsync();
        Task<bool> UpdatePatientAsync(string contact, Patient dto);
        Task<bool> DeletePatientAsync(string contact);
    }

}

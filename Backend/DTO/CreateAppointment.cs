using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Backend.Models.DTO
{
    public class CreateAppointmentRequest
    {
        public string PatientContact { get; set; } = "";
        public decimal Amount { get; set; }
        [JsonIgnore]
        public DateTime AppointmentDate { get; set; }
        public string ServiceDescription { get; set; } = ""; 

    }

}

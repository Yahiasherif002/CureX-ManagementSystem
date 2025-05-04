using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.DTO
{
    public class UpdateStatusRequest
    {
        public string PatientContact { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
    }

}

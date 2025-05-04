using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.DTO
{
    public class AppointmentResponse
    {

        public int AppointmentId { get; set; }

        public string PatientName { get; set; }
            public string PatientContact { get; set; }
            public DateTime AppointmentDate { get; set; }
            public string Status { get; set; }
        public  decimal Amount { get; set; }

        public string ServiceDescription { get; set; } = ""; 
    }


}

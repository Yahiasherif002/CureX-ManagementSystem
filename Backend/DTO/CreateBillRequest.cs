﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.DTO
{
    public class CreateBillRequest
    {
        public string PatientContact { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }

}

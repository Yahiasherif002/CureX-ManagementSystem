using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.DTO
{
    public class BillStatusUpdate
    {
        public int BillId { get; set; }
        public string NewStatus { get; set; }
    }
}

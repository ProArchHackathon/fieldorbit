using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProArch.FieldOrbit.Models
{
    public class WorkRequest : ModelBase
    {
        public int WRNumber { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public string RequestedBy { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }

        public ServiceRequest ServiceRequest { get; set; }
        public Customer Customer { get; set; }
        public List<Job> Jobs { get; set; }
    }
}

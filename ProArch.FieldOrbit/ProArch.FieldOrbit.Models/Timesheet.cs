using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProArch.FieldOrbit.Models
{
    public class Timesheet : ModelBase
    {
        public int CrewId { get; set; }
        public Job Job { get; set; }
        public Customer Customer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EnDate { get; set; }
        public DateTime WorkDate { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public string Comments { get; set; }
    }
}

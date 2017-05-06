using ProArch.FieldOrbit.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProArch.FieldOrbit.Models
{
    public class Job : ModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int EstimatedDuration { get; set; }
        public JobStatus Status { get; set; }
        public JobPriority Priority { get; set; }
        public string Comments { get; set; }
        public string Observations { get; set; }

        public Employee Employee { get; set; }
        public WorkRequest WorkRequest { get; set; }
        public Timesheet Timesheet { get; set; }
    }
}

using ProArch.FieldOrbit.Models.Enums;
using System;
using System.Collections.Generic;

namespace ProArch.FieldOrbit.Models
{
    public class Job : ModelBase
    {
        public int JobId { get; set; }
        public JobStatus Status { get; set; }
        public JobPriority Priority { get; set; }
        public string JobDescription { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        
        public string Comments { get; set; }
        public string Observations { get; set; }

        public WorkRequest WorkRequest { get; set; }
        public List<Employee> Employee { get; set; }        
    }
}

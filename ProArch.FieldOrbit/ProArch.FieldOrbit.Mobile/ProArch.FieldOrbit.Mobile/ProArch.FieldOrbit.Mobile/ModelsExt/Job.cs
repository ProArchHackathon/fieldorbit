using System;

namespace ProArch.FieldOrbit.Models
{
    public class Job : ModelBase
    {
        public int JobId { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public string JobDescription { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string Comments { get; set; }

        public string Observations { get; set; }

        public WorkRequest WorkRequest { get; set; }

        public Employee Employee { get; set; }

        public Customer Customer { get; set; }
    }
}

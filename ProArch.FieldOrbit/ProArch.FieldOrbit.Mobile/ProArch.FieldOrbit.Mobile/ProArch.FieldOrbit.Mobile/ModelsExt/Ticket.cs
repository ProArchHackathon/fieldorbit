using System;

namespace ProArch.FieldOrbit.Models
{
    public class Ticket : ModelBase
    {
        public int Id { get; set; }
        public int EstimatedDuration { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Comments { get; set; }
        public string Observations { get; set; }

        public Job Job { get; set; }
        public Employee Employee { get; set; }
        public Customer Customer { get; set; }
        public WorkRequest WorkRequest { get; set; }
    }
}

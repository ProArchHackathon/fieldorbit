using System;

namespace ProArch.FieldOrbit.Models
{
    public class WorkRequest : ModelBase
    {
        public int WorkRequestId { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ServiceRequest ServiceRequest { get; set; }
        public string Status { get; set; }                
    }
}

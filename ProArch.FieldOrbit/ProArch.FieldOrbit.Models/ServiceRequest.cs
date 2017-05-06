using ProArch.FieldOrbit.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProArch.FieldOrbit.Models
{
    public class ServiceRequest : ModelBase
    {
        public int SRNumber { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public ServiceType ServiceType { get; set; }
        public RequestType RequestType { get; set; }
        public decimal Fees { get; set; }
        public DateTime? ClosedDate { get; set; }
        public string RequestedBy { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }

        public Device Device { get; set; }
        public Customer Customer { get; set; }
        public Employee ClosedBy { get; set; }
        public WorkRequest WorkRequest { get; set; }
    }
}

using ProArch.FieldOrbit.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProArch.FieldOrbit.Models
{
    public class ServiceRequest : ModelBase
    {
        public int ServiceRequestId { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime StartDate { get; set; }
        public ServiceType ServiceType { get; set; }
        public RequestType RequestType { get; set; }

        public Customer Customer { get; set; }
        public Device Device { get; set; }

        public string Location { get; set; }
        public DateTime? EndDate { get; set; }
        public Employee ClosedBy { get; set; }
        public ServiceRequestStatus Status { get; set; }        
    }
}

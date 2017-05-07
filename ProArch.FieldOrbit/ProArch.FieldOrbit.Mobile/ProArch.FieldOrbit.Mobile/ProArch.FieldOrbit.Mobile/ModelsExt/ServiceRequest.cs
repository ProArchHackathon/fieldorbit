using System;
using System.Collections.Generic;

namespace ProArch.FieldOrbit.Models
{
    public class ServiceRequest : ModelBase
    {
        public int ServiceRequestId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? StartDate { get; set; }
        public string ServiceType { get; set; }
        public string RequestType { get; set; }

        public Customer Customer { get; set; }

        public Device Device { get; set; }

        public string Location { get; set; }
        public DateTime? EndDate { get; set; }
        public Employee ClosedBy { get; set; }
        public string Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProArch.FieldOrbit.Models.Enums;

namespace ProArch.FieldOrbit.WebAPI.Models
{
    public class ServiceRequest
    {
        public int ServiceRequestId { get; set; }
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProArch.FieldOrbit.WebAPI.Models
{
    public class WorkRequest
    {
        public int WorkRequestId { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ServiceRequest ServiceRequest { get; set; }
        public string Status { get; set; }
    }
}
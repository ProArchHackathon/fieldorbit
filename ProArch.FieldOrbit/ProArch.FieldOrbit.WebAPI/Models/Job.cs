using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProArch.FieldOrbit.Models.Enums;

namespace ProArch.FieldOrbit.WebAPI.Models
{
    public class Job
    {
        public int JobId { get; set; }
        public JobStatus Status { get; set; }
        public JobPriority Priority { get; set; }
        public string JobDescription { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public string Comments { get; set; }
        public string Observations { get; set; }

        public WorkRequest WorkRequest { get; set; }
        public List<Employee> Employee { get; set; }
    }
}
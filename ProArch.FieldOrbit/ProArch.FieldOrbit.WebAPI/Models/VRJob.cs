using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProArch.FieldOrbit.Models.Enums;

namespace ProArch.FieldOrbit.WebAPI.Models
{
    public class VRJob
    {
        public int JobId { get; set; }
        public string JobDescription { get; set; }
        public JobStatus Status { get; set; }        
    }
}
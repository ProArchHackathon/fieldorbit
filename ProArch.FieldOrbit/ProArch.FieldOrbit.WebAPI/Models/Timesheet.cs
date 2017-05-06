using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProArch.FieldOrbit.WebAPI.Models
{
    public class Timesheet
    {
        public int TimesheetId { get; set; }
        public DateTime WorkDate { get; set; }
        public int Hours { get; set; }
        public string Comments { get; set; }
    }
}
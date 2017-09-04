using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProArch.FieldOrbit.WebAPI.Models
{
    public class TimeSheetUpdater
    {
        public Job Job { get; set; }
        public Timesheet Timesheet { get; set; }
    }
}
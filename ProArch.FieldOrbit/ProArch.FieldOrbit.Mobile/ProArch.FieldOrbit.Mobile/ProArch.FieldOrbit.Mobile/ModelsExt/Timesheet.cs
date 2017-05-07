using System;

namespace ProArch.FieldOrbit.Models
{
    public class Timesheet : ModelBase
    {
        public int TimesheetId { get; set; }

        public DateTime? WorkDate { get; set; }

        public int Hours { get; set; }

        public string Comments { get; set; }
    }
}

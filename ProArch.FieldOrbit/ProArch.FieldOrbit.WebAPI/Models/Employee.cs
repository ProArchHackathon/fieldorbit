using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProArch.FieldOrbit.Models.Enums;

namespace ProArch.FieldOrbit.WebAPI.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public EmployeeType employeetype { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string SSN { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public string VoiceCallUserId { get; set; }
        public List<Timesheet> Timesheets { get; set; }
    }
}
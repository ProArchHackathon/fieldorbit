using ProArch.FieldOrbit.Models.Enums;
using System.Collections.Generic;

namespace ProArch.FieldOrbit.Models
{
    public class Employee : ModelBase
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

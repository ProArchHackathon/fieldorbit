using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProArch.FieldOrbit.Models
{
    public class Employee : ModelBase
    {
        public int Id { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }
        public string SSN { get; set; }
        public string PhoneNumber { get; set; }
        public string VoiceCallUserId { get; set; }
    }
}

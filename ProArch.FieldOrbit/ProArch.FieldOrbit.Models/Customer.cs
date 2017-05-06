using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProArch.FieldOrbit.Models
{
    public class Customer : ModelBase
    {
        [Required]
        public int Id { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
        public string PrimaryContact { get; set; }
        public string SecondaryContact { get; set; }
        public string SSN { get; set; }
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }

        public IList<ServiceRequest> ServiceRequests { get; set; }
    }
}
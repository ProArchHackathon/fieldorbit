using System.ComponentModel.DataAnnotations;

namespace ProArch.FieldOrbit.Models
{
    public class Customer : ModelBase
    {
        [Required]
        public int CustomerId { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string SSN { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }        
    }
}
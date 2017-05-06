using System;

namespace ProArch.FieldOrbit.Models
{
    public class Manufacturer : ModelBase
    {
        public int ManufacturerId { get; set; }
        public string Name { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}

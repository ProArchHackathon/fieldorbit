using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProArch.FieldOrbit.WebAPI.Models
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }
        public string Name { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
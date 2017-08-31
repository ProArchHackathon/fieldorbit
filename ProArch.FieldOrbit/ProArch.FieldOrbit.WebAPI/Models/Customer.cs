using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProArch.FieldOrbit.WebAPI.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string SSN { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public string DeviceId { get; set; }
        public int AssetId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProArch.FieldOrbit.Models.Enums;

namespace ProArch.FieldOrbit.WebAPI.Models
{
    public class Device
    {
        public string DeviceId { get; set; }
        public string DeviceType { get; set; }
        public string ModelNumber { get; set; }
        public decimal Cost { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int YearOfPurchase { get; set; }
        public Manufacturer Manufacturer { get; set; }        
    }
}
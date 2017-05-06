using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProArch.FieldOrbit.Models.Enums;

namespace ProArch.FieldOrbit.WebAPI.Models
{
    public class Device
    {
        public int DeviceId { get; set; }
        public DeviceType DeviceType { get; set; }
        public double ModelNumber { get; set; }
        public decimal Cost { get; set; }
        public int YearOfPurchase { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
using ProArch.FieldOrbit.Models.Enums;
using System.Collections.Generic;

namespace ProArch.FieldOrbit.Models
{
    public class Device : ModelBase
    {
        public int DeviceId { get; set; }
        public DeviceType DeviceType { get; set; }
        public string ModelNumber { get; set; }
        public decimal Cost { get; set; }
        public int YearOfPurchase { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}

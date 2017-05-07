using System;

namespace ProArch.FieldOrbit.Models
{
    public class Device : ModelBase
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

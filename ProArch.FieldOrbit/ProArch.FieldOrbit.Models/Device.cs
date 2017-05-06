using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProArch.FieldOrbit.Models
{
    public class Device : ModelBase
    {
        public int Id { get; set; }
        public int ModelNumber { get; set; }
        public string Type { get; set; }
        public decimal Cost { get; set; }
        public int PurchaseYear { get; set; }
        public ManufacturerDetail ManufactureDetail { get; set; }
        public string PastHistory { get; set; }

        public List<DeviceModel> DeviceModels { get; set; }
    }
}

using System.Collections.Generic;

namespace ProArch.FieldOrbit.Models
{
    public class DeviceExpert : ModelBase
    {
        public int DeviceExpertId { get; set; }

        public Employee Employee { get; set; }

        public List<Device> Devices { get; set; }
    }
}

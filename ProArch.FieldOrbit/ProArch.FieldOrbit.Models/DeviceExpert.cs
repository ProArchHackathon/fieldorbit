using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProArch.FieldOrbit.Models
{
    public class DeviceExpert : ModelBase
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public Device Device { get; set; }
    }
}

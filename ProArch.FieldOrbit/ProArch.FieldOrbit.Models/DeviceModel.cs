using ProArch.FieldOrbit.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProArch.FieldOrbit.Models
{
    public class DeviceModel : ModelBase
    {
        public DeviceModelType Type { get; set; }
        public ContentPath Path { get; set; }
        public bool IsRecommended { get; set; }

        public Device Device { get; set; }
        public Employee UploadedBy { get; set; }
    }
}

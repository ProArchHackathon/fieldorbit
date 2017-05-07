using ProArch.FieldOrbit.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProArch.FieldOrbit.Models.Common
{
    public class EmployeeToken
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public bool Active { get; set; }
        public EmployeeType Type { get; set; }
    }
}

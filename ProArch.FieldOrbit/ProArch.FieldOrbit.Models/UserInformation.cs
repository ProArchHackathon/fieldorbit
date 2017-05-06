using ProArch.FieldOrbit.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProArch.FieldOrbit.Models
{
    public class UserInformation
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public EmployeeType Type { get; set; }
        public int EmployeeId { get; set; }
    }
}

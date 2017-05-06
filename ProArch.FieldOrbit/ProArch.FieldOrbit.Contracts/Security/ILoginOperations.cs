using ProArch.FieldOrbit.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProArch.FieldOrbit.Contracts.Security
{
    public interface ILoginOperations
    {
        TokenHolder Validate();
        bool ValidateToken(string token);
        EmployeeToken DecodeToken(string token);
    }
}

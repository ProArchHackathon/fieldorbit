using ProArch.FieldOrbit.Contracts.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProArch.FieldOrbit.Models.Common;
using ProArch.FieldOrbit.DataLayer.Common;
using ProArch.FieldOrbit.Models;

namespace ProArch.FieldOrbit.BusinessLayer.Security
{
    public class LoginOperationsLogic : ILoginOperations
    {
        public TokenHolder Validate()
        {
            if (IdentityHelper.Identity != null && IdentityHelper.Identity.Headers != null)
            {
                string userName = IdentityHelper.Identity.Headers["username"];
                string password = IdentityHelper.Identity.Headers["password"];
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || !Utilities.Users.Any(c => c.UserName.Equals(userName) && c.Password.Equals(password)))
                {
                    throw new Exception("Invalid username or password.");
                }
                else
                {
                    UserInformation userInfo = Utilities.Users.FirstOrDefault(c => c.UserName.Equals(userName) && c.Password.Equals(password));
                    if (userInfo != null)
                    {
                        return Security.TokenManager.GenerateToken(new EmployeeToken() { Id = userInfo.EmployeeId, Type = userInfo.Type, UserName = userInfo.UserName, Active = true });
                    }
                }
            }
            return null;
        }
    }
}

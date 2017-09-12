using ProArch.FieldOrbit.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProArch.FieldOrbit.DataLayer.Common
{
    public static class Utilities
    {
        public static string MongoServerUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["mongoUrl"];
            }
        }

        public static string MongoServerDB
        {
            get
            {
                return ConfigurationManager.AppSettings["mongoDB"];
            }
        }

        public static List<User> Users
        {
            get
            {
                return new List<User>()
                {
                    //CSR
                    new User() { UserId=1, EmployeeId=1003, UserName="FieldOrbit", Password="Password@1", Type="CSR"},
                    new User() { UserId=1, EmployeeId=1003, UserName="michael", Password="csr123", Type="CSR"},
                    new User() { UserId=2, EmployeeId=1020, UserName="jessi", Password="csr123", Type="CSR"},
                    new User() { UserId=3, EmployeeId=1033, UserName="larry", Password="csr123", Type="CSR"},
                    new User() { UserId=4, EmployeeId=1041, UserName="smith", Password="csr123", Type="CSR"},
                    new User() { UserId=5, EmployeeId=1046, UserName="steven", Password="csr123", Type="CSR"},
                                 
                    //WorkMen    
                    new User() { UserId=6, EmployeeId=1002, UserName="leonard", Password="wm123", Type="WorkMen"},
                    new User() { UserId=7, EmployeeId=1026, UserName="louise", Password="wm123", Type="WorkMen"},
                    new User() { UserId=8, EmployeeId=1027, UserName="jaryl", Password="wm123", Type="WorkMen"},
                    new User() { UserId=9, EmployeeId=1028, UserName="joshua", Password="wm123", Type="WorkMen"},
                    new User() { UserId=10, EmployeeId=1036, UserName="rebecca", Password="wm123", Type="WorkMen"},
                };
            }
        }
    }
}

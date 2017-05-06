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

        public static List<UserInformation> Users
        {
            get
            {
                return new List<UserInformation>()
                {
                    //CSR
                    new UserInformation() { Id=1, EmployeeId=1001, UserName="eva", Password="csr123", Type=Models.Enums.EmployeeType.CSR},
                    new UserInformation() { Id=2, EmployeeId=1010, UserName="nelson", Password="csr123", Type=Models.Enums.EmployeeType.CSR},
                    new UserInformation() { Id=3, EmployeeId=1045, UserName="lindad", Password="csr123", Type=Models.Enums.EmployeeType.CSR},
                    new UserInformation() { Id=4, EmployeeId=1040, UserName="keith", Password="csr123", Type=Models.Enums.EmployeeType.CSR},
                    new UserInformation() { Id=5, EmployeeId=1005, UserName="john", Password="csr123", Type=Models.Enums.EmployeeType.CSR},

                    //WorkMan
                    new UserInformation() { Id=6, EmployeeId=1002, UserName="leonard", Password="wm123", Type=Models.Enums.EmployeeType.WorkMan},
                    new UserInformation() { Id=7, EmployeeId=1003, UserName="michael", Password="wm123", Type=Models.Enums.EmployeeType.WorkMan},
                    new UserInformation() { Id=8, EmployeeId=1004, UserName="michel", Password="wm123", Type=Models.Enums.EmployeeType.WorkMan},
                    new UserInformation() { Id=9, EmployeeId=1008, UserName="shirley", Password="wm123", Type=Models.Enums.EmployeeType.WorkMan},
                    new UserInformation() { Id=10, EmployeeId=1009, UserName="kenneth", Password="wm123", Type=Models.Enums.EmployeeType.WorkMan},
                };
            }
        }
    }
}

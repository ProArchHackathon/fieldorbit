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
    }
}

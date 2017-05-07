﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace ProArch.FieldOrbit.DataLayer.Extensions
{
    public static class StringExtensions
    {
        public static string ValidateData(this string value)
        {
            return value == null ? string.Empty : value;
        }
    }
}

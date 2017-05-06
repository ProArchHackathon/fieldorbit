using ProArch.FieldOrbit.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProArch.FieldOrbit.BusinessLayer.Extensions
{
    public static class ObjectNullExtension
    {
        /// <summary>
        /// Extension method to check if object is null
        /// </summary>
        /// <param name="destinationValue"></param>
        public static bool VerifyObjectNull(this object destinationValue, bool throwEdit = true)
        {
            if (destinationValue == null)
            {
                if (throwEdit)
                {
                    throw new ArgumentNullException(string.Format(CultureInfo.CurrentCulture, "{0}", destinationValue.GetType().Name));
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public static bool VerifyHeaderNull(this object destinationValue, bool throwEdit = true)
        {
            if (destinationValue == null)
            {
                if (throwEdit)
                {
                    throw new EditException() { Edits = (new List<Edit>() { new Edit() { FieldName = "Header", Message = "Invalid Header." } }) };
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}

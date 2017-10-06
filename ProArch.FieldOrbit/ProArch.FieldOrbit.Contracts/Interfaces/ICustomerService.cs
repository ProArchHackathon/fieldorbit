using ProArch.FieldOrbit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProArch.FieldOrbit.Contracts.Interfaces
{
    public interface ICustomerService
    {
        /// <summary>
        /// Get Customer by customer id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Customer GetCustomerById(int customerId);
    }
}
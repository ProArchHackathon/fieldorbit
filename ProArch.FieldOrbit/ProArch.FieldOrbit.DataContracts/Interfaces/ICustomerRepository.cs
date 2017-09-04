using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProArch.FieldOrbit.Models;

namespace ProArch.FieldOrbit.DataContracts.Interfaces
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// get device by device id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Customer GetCustomerById(int customerId);
    }
}


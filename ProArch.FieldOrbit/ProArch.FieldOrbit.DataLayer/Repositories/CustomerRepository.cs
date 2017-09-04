
using ProArch.FieldOrbit.DataContracts.Interfaces;
using ProArch.FieldOrbit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProArch.FieldOrbit.DataLayer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        /// <summary>
        /// get device by id
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public Customer GetCustomerById(int customerId)
        {
            return new MongoRepository().GetCustomer(customerId, "customer");
        }
    }
}
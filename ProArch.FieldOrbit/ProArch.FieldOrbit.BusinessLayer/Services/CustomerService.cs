using ProArch.FieldOrbit.Contracts.Interfaces;
using ProArch.FieldOrbit.DataContracts.Interfaces;
using ProArch.FieldOrbit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProArch.FieldOrbit.BusinessLayer.Services
{
    public class CustomerService : ICustomerService
    {
        public ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Customer GetCustomerById(int customerId)
        {
            return _customerRepository.GetCustomerById(customerId);
        }
    }

}

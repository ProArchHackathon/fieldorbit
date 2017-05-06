using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProArch.FieldOrbit.Contracts.Interfaces;
using ProArch.FieldOrbit.Models;

namespace ProArch.FieldOrbit.BusinessLayer.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class ServiceRequestService : IServiceRequestService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceRequest"></param>
        /// <returns></returns>
        public bool CreateServiceRequest(Models.ServiceRequest serviceRequest)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.ServiceRequest> GetAllServiceRequests()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SRNumber"></param>
        /// <returns></returns>
        public Models.ServiceRequest GetServiceRequestBySRNumber(int SRNumber)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceRequest"></param>
        /// <param name="SRNumber"></param>
        /// <returns></returns>
        public bool UpdateServiceRequest(Models.ServiceRequest serviceRequest, int SRNumber)
        {
            throw new NotImplementedException();
        }
    }
}

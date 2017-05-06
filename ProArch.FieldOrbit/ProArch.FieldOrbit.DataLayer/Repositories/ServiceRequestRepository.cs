using ProArch.FieldOrbit.DataContracts.Interfaces;
using ProArch.FieldOrbit.Models;
using System;
using System.Collections.Generic;

namespace ProArch.FieldOrbit.DataLayer.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class ServiceRequestRepository : IServiceRequestRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceRequest"></param>
        /// <returns></returns>
        public bool CreateServiceRequest(ServiceRequest serviceRequest)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ServiceRequest> GetAllServiceRequests()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SRNumber"></param>
        /// <returns></returns>
        public ServiceRequest GetServiceRequestBySRNumber(int SRNumber)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceRequest"></param>
        /// <param name="SRNumber"></param>
        /// <returns></returns>
        public bool UpdateServiceRequest(ServiceRequest serviceRequest, int SRNumber)
        {
            throw new NotImplementedException();
        }
    }
}

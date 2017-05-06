using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProArch.FieldOrbit.Contracts.Interfaces;
using ProArch.FieldOrbit.Models;
using ProArch.FieldOrbit.BusinessLayer.Extensions;
using ProArch.FieldOrbit.DataContracts.Interfaces;

namespace ProArch.FieldOrbit.BusinessLayer.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class ServiceRequestService : IServiceRequestService
    {
        private IServiceRequestRepository serviceRequestRepository;
        public ServiceRequestService(IServiceRequestRepository serviceRequestRepository)
        {
            this.serviceRequestRepository = serviceRequestRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceRequest"></param>
        /// <returns></returns>
        public bool CreateServiceRequest(Models.ServiceRequest serviceRequest)
        {
            serviceRequest.VerifyObjectNull();
            return this.serviceRequestRepository.CreateServiceRequest(serviceRequest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.ServiceRequest> GetAllServiceRequests()
        {
            return this.serviceRequestRepository.GetAllServiceRequests();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SRNumber"></param>
        /// <returns></returns>
        public Models.ServiceRequest GetServiceRequestBySRNumber(int serviceRequestId)
        {
            return this.serviceRequestRepository.GetServiceRequestBySRNumber(serviceRequestId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceRequest"></param>
        /// <param name="SRNumber"></param>
        /// <returns></returns>
        public bool UpdateServiceRequest(Models.ServiceRequest serviceRequest, int serviceRequestNbr)
        {
            serviceRequest.VerifyObjectNull();
            return this.serviceRequestRepository.UpdateServiceRequest(serviceRequest, serviceRequestNbr);
        }
    }
}

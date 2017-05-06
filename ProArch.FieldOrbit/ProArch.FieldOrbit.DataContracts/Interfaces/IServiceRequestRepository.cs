using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProArch.FieldOrbit.Models;

namespace ProArch.FieldOrbit.DataContracts.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IServiceRequestRepository
    {
        /// <summary>
        /// Create service request
        /// </summary>
        /// <param name="serviceRequest"></param>
        /// <returns></returns>
        bool CreateServiceRequest(ServiceRequest serviceRequest);

        /// <summary>
        /// Update service request
        /// </summary>
        /// <param name="serviceRequest"></param>
        /// <param name="SRNumber"></param>
        /// <returns></returns>
        bool UpdateServiceRequest(ServiceRequest serviceRequest, int SRNumber);

        /// <summary>
        /// get service request by service request number
        /// </summary>
        /// <param name="serviceRequestId"></param>
        /// <returns></returns>
        ServiceRequest GetServiceRequestBySRNumber(int serviceRequestId);
        
        /// <summary>
        /// Get All Service Requests
        /// </summary>
        /// <returns></returns>
        IEnumerable<ServiceRequest> GetAllServiceRequests();
    }
}

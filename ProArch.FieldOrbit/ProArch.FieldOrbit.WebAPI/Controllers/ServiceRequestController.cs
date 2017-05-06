using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ProArch.FieldOrbit.Contracts.Interfaces;
using ProArch.FieldOrbit.Models;
using ProArch.FieldOrbit.WebApi.Filters;

namespace ProArch.FieldOrbit.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    [ExceptionHandlerFilterAttribute]
    public class ServiceRequestController : ApiController
    {
        private IServiceRequestService serviceRequest;

        public ServiceRequestController(IServiceRequestService serviceRequest)
        {
            this.serviceRequest = serviceRequest;
        }

        [HttpPost]
        public HttpResponseMessage Post()
        {
            ServiceRequest serviceRequest = new ServiceRequest();
            serviceRequest.CreatedDate = DateTime.Now;
            serviceRequest.EndDate = DateTime.Now.AddDays(15);
            serviceRequest.ClosedBy = serviceRequest.ClosedBy ?? new Employee() { EmployeeId = 1002 };
            serviceRequest.Customer = serviceRequest.Customer ?? new Customer() { CustomerId = 2 };
            serviceRequest.ServiceType = ProArch.FieldOrbit.Models.Enums.ServiceType.Electric;
            serviceRequest.RequestType = ProArch.FieldOrbit.Models.Enums.RequestType.Connect;
            serviceRequest.Device = serviceRequest.Device ?? new Device() { DeviceId = 2, DeviceType = ProArch.FieldOrbit.Models.Enums.DeviceType.Amplifier, ModelNumber = 456 };
            serviceRequest.Location = "abc123";
            serviceRequest.Status = ProArch.FieldOrbit.Models.Enums.ServiceRequestStatus.Open;

            var isSuccess = this.serviceRequest.CreateServiceRequest(serviceRequest);
            //var isSuccess = this.serviceRequest.UpdateServiceRequest(serviceRequest,15);
            return Request.CreateResponse(HttpStatusCode.OK, isSuccess);
        }

        [HttpGet]
        public HttpResponseMessage GetServiceRequest(int serviceRequestId)
        {
            var isSuccess = this.serviceRequest.GetServiceRequestBySRNumber(serviceRequestId);
            return Request.CreateResponse(HttpStatusCode.OK, isSuccess);
        }
    }
}

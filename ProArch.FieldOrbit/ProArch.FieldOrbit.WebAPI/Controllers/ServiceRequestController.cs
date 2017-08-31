﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ProArch.FieldOrbit.Contracts.Interfaces;
using ProArch.FieldOrbit.WebApi.Filters;
using ProArch.FieldOrbit.WebAPI.Models;
using AutoMapper;

namespace ProArch.FieldOrbit.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    [ExceptionHandlerFilterAttribute]
    [RoutePrefix("api/ServiceRequest")]
    public class ServiceRequestController : ApiController
    {
        private IServiceRequestService serviceRequest;

        public ServiceRequestController(IServiceRequestService serviceRequest)
        {
            this.serviceRequest = serviceRequest;
        }

        [HttpPost]
        [TraceLogActionFilter]
        [Route("Post")]
        public bool Post([FromBody]ServiceRequest serviceRequest)
        {
            return this.serviceRequest.CreateServiceRequest(Mapper.Map<ProArch.FieldOrbit.Models.ServiceRequest>(serviceRequest));
        }

        [HttpPut]
        [TraceLogActionFilter]
        [Route("Update")]
        public bool Update(ServiceRequest serviceRequest)
        {
            return this.serviceRequest.UpdateServiceRequest(Mapper.Map<ProArch.FieldOrbit.Models.ServiceRequest>(serviceRequest));
        }

        [HttpGet]
        [TraceLogActionFilter]
        [Route("GetServiceRequest")]
        public ServiceRequest GetServiceRequest(int serviceRequestId)
        {
            return Mapper.Map<ServiceRequest>(this.serviceRequest.GetServiceRequestBySRNumber(serviceRequestId));
        }

        [HttpGet]
        [TraceLogActionFilter]
        [Route("GetAllServiceRequest")]
        public IEnumerable<ServiceRequest> GetAllServiceRequest(string type)
        {
            return Mapper.Map<IEnumerable<ServiceRequest>>(this.serviceRequest.GetAllServiceRequests(type));
        }
    }
}

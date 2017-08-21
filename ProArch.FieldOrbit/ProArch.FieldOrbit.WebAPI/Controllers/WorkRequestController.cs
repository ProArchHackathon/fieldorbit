using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
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
    public class WorkRequestController : ApiController
    {
        readonly IWorkRequestService _WorkRequestService;

        public WorkRequestController(IWorkRequestService workRequestService)
        {
            this._WorkRequestService = workRequestService;
        }

        [HttpPost]
        [TraceLogActionFilterAttribute]
        public bool Post(WorkRequest workRequest)
        {
            return this._WorkRequestService.CreateWorkRequest(Mapper.Map<ProArch.FieldOrbit.Models.WorkRequest>(workRequest));
        }

        [HttpPut]
        [TraceLogActionFilterAttribute]
        public bool Put(WorkRequest workRequest)
        {
            return this._WorkRequestService.UpdateWorkRequest(Mapper.Map<ProArch.FieldOrbit.Models.WorkRequest>(workRequest));
        }

        [HttpGet]
        [TraceLogActionFilterAttribute]
        public WorkRequest Get(int workRequestNumber)
        {
            return Mapper.Map<WorkRequest>(this._WorkRequestService.GetWorkRequestByID(workRequestNumber));
        }
    }
}
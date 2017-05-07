using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using ProArch.FieldOrbit.Contracts.Interfaces;
using ProArch.FieldOrbit.Models;
using ProArch.FieldOrbit.WebApi.Filters;

namespace ProArch.FieldOrbit.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    [ExceptionHandlerFilterAttribute]
    public class JobController : ApiController
    {
        private IJobService jobRequest;

        public JobController(IJobService jobRequest)
        {
            this.jobRequest = jobRequest;
        }

        [HttpPost]
        [TraceLogActionFilter]
        public bool Post(Job jobRequest)
        {
            return this.jobRequest.CreateJob(Mapper.Map<ProArch.FieldOrbit.Models.Job>(jobRequest));
        }

        [HttpPut]
        [TraceLogActionFilter]
        public bool Update(Job jobRequest)
        {
            return this.jobRequest.UpdateJob(Mapper.Map<ProArch.FieldOrbit.Models.Job>(jobRequest));
        }

        [HttpPut]
        [TraceLogActionFilter]
        public bool Update(int JobID, string Status, string Comments, string Observations)
        {
            return this.jobRequest.UpdateJobWithComments(JobID, Status, Comments, Observations);
        }

        [HttpGet]
        [TraceLogActionFilter]
        public Job GetJobByID(int jobId)
        {
            return Mapper.Map<Job>(this.jobRequest.GetJobByID(jobId));
        }

        //[HttpGet]
        //[TraceLogActionFilter]
        //public IEnumerable<Job> GetUserJob()
        //{
        //    var claimsIdentity = HttpContext.Current.User.Identity as ClaimsIdentity;
        //    return this.jobRequest.GetUserJob(claimsIdentity.Claims.First(x=>));
        //}

    }
}
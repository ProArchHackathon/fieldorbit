﻿using System;
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
        private IJobService _jobService;

        public JobController(IJobService jobRequest)
        {
            _jobService = jobRequest;
        }

        [HttpPost]
        [TraceLogActionFilter]
        public bool Post(Job job)
        {
            return _jobService.CreateJob(Mapper.Map<ProArch.FieldOrbit.Models.Job>(job));
        }

        [HttpPut]
        [TraceLogActionFilter]
        public bool Update(Job jobRequest)
        {
            return _jobService.UpdateJob(Mapper.Map<ProArch.FieldOrbit.Models.Job>(jobRequest));
        }

        [HttpPut]
        [TraceLogActionFilter]
        public bool Update(int JobID, string Status, string Comments, string Observations)
        {
            return _jobService.UpdateJobWithComments(JobID, Status, Comments, Observations);
        }

        [HttpGet]
        [TraceLogActionFilter]
        public Job GetJobByID(int jobId)
        {
            return Mapper.Map<Job>(_jobService.GetJobByID(jobId));
        }

        [HttpGet]
        [TraceLogActionFilter]
        public IEnumerable<Job> GetUserJob(int employeeId)
        {
            return _jobService.GetUserJob(employeeId);
        }
    }
}
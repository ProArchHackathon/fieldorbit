using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProArch.FieldOrbit.Contracts.Interfaces;
using ProArch.FieldOrbit.DataContracts.Interfaces;
using ProArch.FieldOrbit.Models;
using ProArch.FieldOrbit.BusinessLayer.Streaming;
using ProArch.FieldOrbit.BusinessLayer.Extensions;

namespace ProArch.FieldOrbit.BusinessLayer.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class JobService : IJobService
    {
        private IJobRepository jobRepository;
        public JobService(IJobRepository jobRepository)
        {
            this.jobRepository = jobRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public bool CreateJob(Models.Job job)
        {
            job.VerifyObjectNull();
            return this.jobRepository.CreateJob(job);
        }

        public bool EnterTimeSheet(Job job, Timesheet timeSheet)
        {
            return this.jobRepository.EnterTimeSheet(job, timeSheet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        public Models.Job GetJobByID(int JobId)
        {
            return this.jobRepository.GetJobByID(JobId);
        }

        /// <summary>
        /// Gets all jobs list
        /// </summary>
        /// <returns></returns>
        public List<Models.Job> GetJobs()
        {
            return this.jobRepository.GetAllJobs();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        public Models.VRJob GetVRJobByID(int JobId)
        {
            return this.jobRepository.GetVRJobByID(JobId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <returns></returns>
        public List<Models.Job> GetUserJob(int EmployeeID)
        {
            return this.jobRepository.GetUserJob(EmployeeID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public bool UpdateJob(Models.Job job)
        {
            return this.jobRepository.UpdateJob(job);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JobID"></param>
        /// <param name="Status"></param>
        /// <param name="Comments"></param>
        /// <param name="Observations"></param>
        /// <returns></returns>
        public bool UpdateJobWithComments(int JobID, string Status, string Comments, string Observations)
        {
            return this.jobRepository.UpdateJob(JobID,Status,Comments,Observations);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProArch.FieldOrbit.Contracts.Interfaces;
using ProArch.FieldOrbit.Models;
using ProArch.FieldOrbit.BusinessLayer.Streaming;

namespace ProArch.FieldOrbit.BusinessLayer.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class JobService : IJobService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public bool CreateJob(Models.Job job)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        public Models.Job GetJobByID(int JobId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <returns></returns>
        public List<Models.Job> GetUserJob(int EmployeeID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public bool UpdateJob(Models.Job job)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JobID"></param>
        /// <param name="Status"></param>
        /// <param name="Comments"></param>
        /// <param name="Observations"></param>
        /// <returns></returns>
        public bool UpdateJob(int JobID, string Status, string Comments, string Observations)
        {
            throw new NotImplementedException();
        }
    }
}

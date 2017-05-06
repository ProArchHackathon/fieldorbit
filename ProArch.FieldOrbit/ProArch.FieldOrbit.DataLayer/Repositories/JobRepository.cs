using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProArch.FieldOrbit.DataContracts.Interfaces;
using ProArch.FieldOrbit.Models;

namespace ProArch.FieldOrbit.DataLayer.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class JobRepository : IJobRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public bool CreateJob(Job job)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        public Job GetJobByID(int JobId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JobID"></param>
        /// <returns></returns>
        public Job GetJobDetails(int JobID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <returns></returns>
        public List<Job> GetUserJob(int EmployeeID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        public Stream GetVideoContent(string URL)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="VideoID"></param>
        /// <param name="VideoType"></param>
        /// <returns></returns>
        public string GetVideoPath(string VideoID, string VideoType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="job"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool UpdateJob(Job job, int Id)
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

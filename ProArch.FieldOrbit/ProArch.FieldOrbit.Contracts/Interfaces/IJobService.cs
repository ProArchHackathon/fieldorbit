using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProArch.FieldOrbit.Models;

namespace ProArch.FieldOrbit.Contracts.Interfaces
{
    /// <summary>
    /// Job interface
    /// </summary>
    public interface IJobService
    {
        /// <summary>
        /// Create Job
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        bool CreateJob(Job job);

        /// <summary>
        /// Update Job
        /// </summary>
        /// <param name="job"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool UpdateJob(Job job, int Id);

        /// <summary>
        /// Get job by job id
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        Job GetJobByID(int JobId);

        /// <summary>
        /// Get jobs by emplyeeid
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <returns></returns>
        List<Job> GetUserJob(int EmployeeID);

        /// <summary>
        /// Get job details
        /// </summary>
        /// <param name="JobID"></param>
        /// <returns></returns>
        Job GetJobDetails(int JobID);

        /// <summary>
        /// Update job
        /// </summary>
        /// <param name="JobID"></param>
        /// <param name="Status"></param>
        /// <param name="Comments"></param>
        /// <param name="Observations"></param>
        /// <returns></returns>
        bool UpdateJob(int JobID, string Status, string Comments, string Observations);

        /// <summary>
        /// Get video path
        /// </summary>
        /// <param name="VideoID"></param>
        /// <param name="VideoType"></param>
        /// <returns></returns>
        string GetVideoPath(string VideoID,string VideoType);

        /// <summary>
        /// Get video content
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        Stream GetVideoContent(string URL);
    }
}

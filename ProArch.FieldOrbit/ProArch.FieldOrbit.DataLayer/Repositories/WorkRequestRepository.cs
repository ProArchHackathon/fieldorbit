using ProArch.FieldOrbit.DataContracts.Interfaces;
using ProArch.FieldOrbit.Models;
using System;

namespace ProArch.FieldOrbit.DataLayer.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class WorkRequestRepository : IWorkRequestRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workRequest"></param>
        /// <returns></returns>
        public bool CreateWorkRequest(WorkRequest workRequest)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="WRNumber"></param>
        /// <returns></returns>
        public WorkRequest GetWorkRequestByID(int WRNumber)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workRequest"></param>
        /// <param name="WRNumber"></param>
        /// <returns></returns>
        public bool UpdateWorkRequest(WorkRequest workRequest, int WRNumber)
        {
            throw new NotImplementedException();
        }
    }
}

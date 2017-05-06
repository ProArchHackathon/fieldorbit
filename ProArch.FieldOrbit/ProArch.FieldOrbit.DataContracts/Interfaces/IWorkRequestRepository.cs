using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProArch.FieldOrbit.Models;

namespace ProArch.FieldOrbit.DataContracts.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IWorkRequestRepository
    {
        /// <summary>
        /// Create work request
        /// </summary>
        /// <param name="workRequest"></param>
        /// <returns></returns>
        bool CreateWorkRequest(WorkRequest workRequest);

        /// <summary>
        /// Update work request
        /// </summary>
        /// <param name="workRequest"></param>
        /// <returns></returns>
        bool UpdateWorkRequest(WorkRequest workRequest);

        /// <summary>
        /// Get work request by work request id
        /// </summary>
        /// <param name="WRNumber"></param>
        /// <returns></returns>
        WorkRequest GetWorkRequestByID(int WRNumber);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProArch.FieldOrbit.Models;

namespace ProArch.FieldOrbit.Contracts.Interfaces
{
    /// <summary>
    /// work request interface
    /// </summary>
    public interface IWorkRequestService
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

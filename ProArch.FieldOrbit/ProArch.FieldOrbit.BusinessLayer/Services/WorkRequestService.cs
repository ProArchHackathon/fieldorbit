using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProArch.FieldOrbit.Contracts.Interfaces;
using ProArch.FieldOrbit.Models;

namespace ProArch.FieldOrbit.BusinessLayer.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class WorkRequestService : IWorkRequestService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workRequest"></param>
        /// <returns></returns>
        public bool CreateWorkRequest(Models.WorkRequest workRequest)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="WRNumber"></param>
        /// <returns></returns>
        public Models.WorkRequest GetWorkRequestByID(int WRNumber)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workRequest"></param>
        /// <param name="WRNumber"></param>
        /// <returns></returns>
        public bool UpdateWorkRequest(Models.WorkRequest workRequest, int WRNumber)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
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
    public class DeviceRepository : IDeviceRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceModel"></param>
        /// <returns></returns>
        public bool AddDeviceInfo(DeviceModel deviceModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<DeviceModel> GetAllDevices()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DeviceID"></param>
        /// <returns></returns>
        public Device GetDeviceByID(int DeviceID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DeviceID"></param>
        /// <returns></returns>
        public string GetExpert(int DeviceID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceModel"></param>
        /// <param name="DeviceID"></param>
        /// <returns></returns>
        public bool UpdateDeviceInfo(DeviceModel deviceModel, int DeviceID)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProArch.FieldOrbit.Contracts.Interfaces;
using ProArch.FieldOrbit.Models;
using ProArch.FieldOrbit.DataContracts.Interfaces;

namespace ProArch.FieldOrbit.BusinessLayer.Services
{
    /// <summary>
    /// Device service
    /// </summary>
    public class DeviceService : IDeviceService
    {

        private IDeviceRepository _deviceRepository;
        public DeviceService(IDeviceRepository deviceRepository)
        {
            this._deviceRepository = deviceRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public bool AddDeviceInfo(Content content)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Device> GetAllDevices()
        {
            return this._deviceRepository.GetAllDevices().ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DeviceID"></param>
        /// <returns></returns>
        public Models.Device GetDeviceByID(int DeviceID)
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
        /// <param name="content"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public bool UpdateDeviceInfo(Content content, int deviceId)
        {
            throw new NotImplementedException();
        }
    }
}

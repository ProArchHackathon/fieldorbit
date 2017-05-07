using ProArch.FieldOrbit.DataContracts.Interfaces;
using ProArch.FieldOrbit.Models;
using System;
using System.Collections.Generic;

namespace ProArch.FieldOrbit.DataLayer.Repositories
{
    /// <summary>
    /// Device Repository
    /// </summary>
    public class DeviceRepository : IDeviceRepository
    {
        /// <summary>
        /// add device info
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public bool AddDeviceInfo(Content content)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// get all devices
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Device> GetAllDevices()
        {
            return new MongoRepository().GetAllDevices("device");
        }

        /// <summary>
        /// get device by id
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public Device GetDeviceById(int deviceId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// get expert
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public DeviceExpert GetExpert(string deviceId)
        {
            return new MongoRepository().GetExpert(deviceId, "deviceexpert");
        }

        /// <summary>
        /// update device info
        /// </summary>
        /// <param name="content"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public bool UpdateDeviceInfo(Content content, int deviceId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// get video path
        /// 
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="videoType"></param>
        /// <returns></returns>
        public string GetVideoPath(string deviceId, string videoType)
        {
            return new MongoRepository().GetVideoPath(deviceId, videoType, "content");
        }
    }
}

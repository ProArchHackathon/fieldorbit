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
    public interface IDeviceRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        bool AddDeviceInfo(Content content);

        /// <summary>
        /// Update device information
        /// </summary>
        /// <param name="content"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        bool UpdateDeviceInfo(Content content, int deviceId);

        /// <summary>
        /// get device by device id
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        Device GetDeviceById(string deviceId);

        /// <summary>
        /// get all devices
        /// </summary>
        /// <returns></returns>
        IEnumerable<Device> GetAllDevices();

        /// <summary>
        /// get expert by device id
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        DeviceExpert GetExpert(string deviceId);

        /// <summary>
        /// get video path
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="videoType"></param>
        /// <returns></returns>
        string GetVideoPath(string deviceId, string videoType);
        List<Job> GetCustomerDevices(int customerId);
    }
}

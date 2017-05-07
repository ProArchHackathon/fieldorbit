using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProArch.FieldOrbit.Models;
using System.IO;

namespace ProArch.FieldOrbit.Contracts.Interfaces
{
    /// <summary>
    /// Device interface
    /// </summary>
    public interface IDeviceService
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
        /// Get Device by device id
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        Device GetDeviceById(string deviceId);

        /// <summary>
        /// Get all devices
        /// </summary>
        /// <returns></returns>
        IEnumerable<Device> GetAllDevices();

        /// <summary>
        /// Get expert by device id
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        DeviceExpert GetExpert(string deviceId);

        /// <summary>
        /// Get video path
        /// </summary>
        /// <param name="VideoID"></param>
        /// <param name="VideoType"></param>
        /// <returns></returns>
        string GetVideoPath(string VideoID, string VideoType);

        /// <summary>
        /// Get video content
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        Stream GetVideoContent(string URL);
        List<Job> GetCustomerDevices(int customerId);
    }
}

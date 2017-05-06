using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProArch.FieldOrbit.Models;

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
        Device GetDeviceByID(int deviceId);

        /// <summary>
        /// Get all devices
        /// </summary>
        /// <returns></returns>
        List<Content> GetAllDevices();

        /// <summary>
        /// Get expert by device id
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        string GetExpert(int deviceId);
    }
}

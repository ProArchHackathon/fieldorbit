using ProArch.FieldOrbit.BusinessLayer.Streaming;
using ProArch.FieldOrbit.Contracts.Interfaces;
using ProArch.FieldOrbit.DataContracts.Interfaces;
using ProArch.FieldOrbit.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ProArch.FieldOrbit.BusinessLayer.Services
{
    /// <summary>
    /// Device service
    /// </summary>
    public class DeviceService : IDeviceService
    {
        public IDeviceRepository _deviceRepository;

        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
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
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public Models.Device GetDeviceById(string deviceId)
        {
            return _deviceRepository.GetDeviceById(deviceId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public DeviceExpert GetExpert(string deviceId)
        {
            return _deviceRepository.GetExpert(deviceId);
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

        /// <summary>
        /// getvideocontent
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        public Stream GetVideoContent(string URL)
        {
            return ContentService.GetVideoContent(URL);
        }

        /// <summary>
        /// get video path
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="videoType"></param>
        /// <returns></returns>
        public string GetVideoPath(string deviceId, string videoType)
        {
            string filename = _deviceRepository.GetVideoPath(deviceId, videoType);
            return ContentService.GetVideoPath(filename);
        }

        /// <summary>
        /// get customer devices
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public List<Job> GetCustomerDevices(int customerId)
        {
            return _deviceRepository.GetCustomerDevices(customerId);
        }

        /// <summary>
        /// upload files
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public bool UploadFiles(HttpFileCollectionBase files)
        {
            return ContentService.UploadFiles(files);
        }
    }
}

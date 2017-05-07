using AutoMapper;
using ProArch.FieldOrbit.Contracts.Interfaces;
using ProArch.FieldOrbit.Models;
using ProArch.FieldOrbit.WebApi.Filters;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProArch.FieldOrbit.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    [ExceptionHandlerFilterAttribute]
    public class DeviceController : ApiController
    {
        public IDeviceService _deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        [HttpPost]
        [TraceLogActionFilter]
        [Route("api/Device/AddDeviceInfo")]
        public bool AddDeviceInfo(Content content)
        {
            return _deviceService.AddDeviceInfo(content);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>      
		[TraceLogActionFilterAttribute]
        [Route("api/Device/GetAllDevices")]
        public IEnumerable<Device> GetAllDevices()
        {
            return Mapper.Map<IEnumerable<Device>>(_deviceService.GetAllDevices());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        [HttpGet]
        [TraceLogActionFilter]
        [ActionName("GetDeviceById")]
        public Device GetDeviceById(string deviceId)
        {
            return _deviceService.GetDeviceById(deviceId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        [TraceLogActionFilter]
        [Route("api/Device/GetExpert")]
        public DeviceExpert GetExpert(string deviceId)
        {
            return _deviceService.GetExpert(deviceId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        [HttpPost]
        [TraceLogActionFilter]
        [Route("api/Device/UpdateDeviceInfo")]
        public bool UpdateDeviceInfo(Content content, int deviceId)
        {
            return _deviceService.UpdateDeviceInfo(content, deviceId);
        }

        /// <summary>
        /// get video path
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="videoType"></param>
        /// <returns></returns>
        [TraceLogActionFilter]
        [Route("api/Device/GetVideoPath")]
        public string GetVideoPath(string deviceId, string videoType)
        {
            return _deviceService.GetVideoPath(deviceId, videoType);
        }

        [TraceLogActionFilter]
        [Route("api/Device/GetCustomerDevices")]
        public List<Job> GetCustomerDevices(int customerId)
        {
            return _deviceService.GetCustomerDevices(customerId);
        }

        /// <summary>
        /// uploadfiles
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [TraceLogActionFilter]
        [Route("api/Device/UploadFiles")]
        public bool UploadFiles(HttpRequestBase request)
        {
            return _deviceService.UploadFiles(request.Files);
        }

        /// <summary>
        /// getvideocontent
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        [TraceLogActionFilter]
        [Route("api/Device/GetVideoContent")]
        public Stream GetVideoContent(string url)
        {
            return _deviceService.GetVideoContent(url);
        }
    }
}

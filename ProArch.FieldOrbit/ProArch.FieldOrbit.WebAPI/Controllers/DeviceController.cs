using AutoMapper;
using ProArch.FieldOrbit.Contracts.Interfaces;
using ProArch.FieldOrbit.Models;
using ProArch.FieldOrbit.WebApi.Filters;
using System.Collections.Generic;
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
            return Mapper.Map<IEnumerable<Device>>(this._deviceService.GetAllDevices());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>      
		[TraceLogActionFilterAttribute]
        [Route("api/Device/GetDeviceById")]
        public Device GetAllDevices(string deviceId)
        {
            return Mapper.Map<Device>(_deviceService.GetDeviceById(deviceId));            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        [HttpGet]
        [TraceLogActionFilter]
        [ActionName("getdevicebyid")]
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
        [Route("api/Device/GetVideoPath")]
        public string GetVideoPath(string deviceId, string videoType)
        {
            return _deviceService.GetVideoPath(deviceId, videoType);
        }

        [Route("api/Device/GetCustomerDevices")]
        public List<Job> GetCustomerDevices(int customerId)
        {
            return _deviceService.GetCustomerDevices(customerId);
        }
    }
}

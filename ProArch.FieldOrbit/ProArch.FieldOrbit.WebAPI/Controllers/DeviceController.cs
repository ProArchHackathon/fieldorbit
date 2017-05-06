using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using ProArch.FieldOrbit.Contracts.Interfaces;
using ProArch.FieldOrbit.WebApi.Filters;
using ProArch.FieldOrbit.WebAPI.Models;
using AutoMapper;

namespace ProArch.FieldOrbit.WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    [ExceptionHandlerFilterAttribute]
    public class DeviceController : ApiController
    {
        readonly IDeviceService _DeviceService;

        public DeviceController(IDeviceService DeviceService)
        {
            this._DeviceService = DeviceService;
        }

        [HttpPost]
        [TraceLogActionFilterAttribute]
        public bool Post(Device Device)
        {
            //return this._DeviceService.CreateDevice(Mapper.Map<ProArch.FieldOrbit.Models.Device>(Device));
            return true;
        }

        [HttpPut]
        [TraceLogActionFilterAttribute]
        public bool Put(Device Device, int DeviceNumber)
        {
            //return this._DeviceService.UpdateDevice(Mapper.Map<ProArch.FieldOrbit.Models.Device>(Device), DeviceNumber);
            return true;
        }

        [TraceLogActionFilterAttribute]
        [Route("api/Device/GetAllDevices")]
        public IEnumerable<Device> GetAllDevices()
        {
            return Mapper.Map<IEnumerable<Device>>(this._DeviceService.GetAllDevices());
        }

        [HttpGet]
        [TraceLogActionFilterAttribute]
        public Device Get(int DeviceNumber)
        {
            return Mapper.Map<Device>(this._DeviceService.GetDeviceByID(DeviceNumber));
        }
    }
}
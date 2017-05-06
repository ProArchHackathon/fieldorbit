using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViewModels = ProArch.FieldOrbit.WebAPI.Models;
using DomainModels = ProArch.FieldOrbit.Models;

namespace ProArch.FieldOrbit.WebAPI.App_Start.Profiles
{
    /// <summary>
    /// Auto mapper class for Field Orbit.
    /// </summary>
    /// <seealso cref="SEDC.UPN.CA.AM.Web.Api.App_Start.Profiles.BaseProfile" />
    public class FieldOrbitProfile : BaseProfile
    {
        /// <summary>
        /// Creates the maps.
        /// </summary>
        protected override void CreateMaps()
        {
            //View models to Models
            MapWorkRequestViewModelToModel();

            //Models to View models
            MapWorkRequestModelToViewModel();
        }

        private void MapWorkRequestViewModelToModel()
        {
            var workRequestMap = CreateMap<ViewModels.WorkRequest, DomainModels.WorkRequest>();
            workRequestMap.ForAllMembers(opt => opt.Ignore());
            workRequestMap.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.WorkRequestId, opt => opt.MapFrom(src => src.WorkRequestId))
            .ForMember(dest => dest.ServiceRequest, opt => opt.MapFrom(src => new DomainModels.ServiceRequest()
            {
                ClosedBy = new DomainModels.Employee()
                {
                    EmployeeId = src.ServiceRequest.ClosedBy.EmployeeId,
                },
                CreatedDate = src.ServiceRequest.CreatedDate,
                EndDate = src.ServiceRequest.EndDate,
                Location = src.ServiceRequest.Location,
                ServiceRequestId = src.ServiceRequest.ServiceRequestId,
                RequestType = src.ServiceRequest.RequestType,
                ServiceType = src.ServiceRequest.ServiceType,
                StartDate = src.ServiceRequest.StartDate,
                Status = src.ServiceRequest.Status,
                Customer = new DomainModels.Customer()
                {
                    CustomerId = src.ServiceRequest.Customer.CustomerId,
                    Active = src.ServiceRequest.Customer.Active,
                    Address = new DomainModels.Address()
                    {
                        Street = src.ServiceRequest.Customer.Address.Street,
                        City = src.ServiceRequest.Customer.Address.City,
                        State = src.ServiceRequest.Customer.Address.State,
                        Zip = src.ServiceRequest.Customer.Address.Zip,
                    },
                    Email = src.ServiceRequest.Customer.Email,
                    Phone = src.ServiceRequest.Customer.Phone,
                    SSN = src.ServiceRequest.Customer.SSN,
                    Name = new DomainModels.Name()
                    {
                        FirstName = src.ServiceRequest.Customer.Name.FirstName,
                        MiddleName = src.ServiceRequest.Customer.Name.MiddleName,
                        LastName = src.ServiceRequest.Customer.Name.LastName
                    }
                },
                Device = new DomainModels.Device()
                {
                    DeviceId = src.ServiceRequest.Device.DeviceId,
                    DeviceType = src.ServiceRequest.Device.DeviceType,
                    ModelNumber = src.ServiceRequest.Device.ModelNumber
                }
            }));
        }

        private void MapWorkRequestModelToViewModel()
        {
            var workRequestMap = CreateMap<DomainModels.WorkRequest, ViewModels.WorkRequest>();
            workRequestMap.ForAllMembers(opt => opt.Ignore());
            workRequestMap.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.WorkRequestId, opt => opt.MapFrom(src => src.WorkRequestId))
            .ForMember(dest => dest.ServiceRequest, opt => opt.MapFrom(src => new ViewModels.ServiceRequest()
            {
                ClosedBy = new ViewModels.Employee()
                {
                    EmployeeId = src.ServiceRequest.ClosedBy.EmployeeId,
                },
                CreatedDate = src.ServiceRequest.CreatedDate,
                EndDate = src.ServiceRequest.EndDate,
                Location = src.ServiceRequest.Location,
                ServiceRequestId = src.ServiceRequest.ServiceRequestId,
                RequestType = src.ServiceRequest.RequestType,
                ServiceType = src.ServiceRequest.ServiceType,
                StartDate = src.ServiceRequest.StartDate,
                Status = src.ServiceRequest.Status,
                Customer = new ViewModels.Customer()
                {
                    CustomerId = src.ServiceRequest.Customer.CustomerId,
                    Active = src.ServiceRequest.Customer.Active,
                    Address = new ViewModels.Address()
                    {
                        Street = src.ServiceRequest.Customer.Address == null ? string.Empty : src.ServiceRequest.Customer.Address.Street,
                        City = src.ServiceRequest.Customer.Address == null ? string.Empty : src.ServiceRequest.Customer.Address.City,
                        State = src.ServiceRequest.Customer.Address == null ? string.Empty : src.ServiceRequest.Customer.Address.State,
                        Zip = src.ServiceRequest.Customer.Address == null ? string.Empty : src.ServiceRequest.Customer.Address.Zip,
                    },
                    Email = src.ServiceRequest.Customer.Email,
                    Phone = src.ServiceRequest.Customer.Phone,
                    SSN = src.ServiceRequest.Customer.SSN,
                    Name = new ViewModels.Name()
                    {
                        FirstName = src.ServiceRequest.Customer.Name == null ? string.Empty : src.ServiceRequest.Customer.Name.FirstName,
                        MiddleName = src.ServiceRequest.Customer.Name == null ? string.Empty : src.ServiceRequest.Customer.Name.MiddleName,
                        LastName = src.ServiceRequest.Customer.Name == null ? string.Empty : src.ServiceRequest.Customer.Name.LastName
                    }
                },
                Device = new ViewModels.Device()
                {
                    DeviceId = src.ServiceRequest.Device.DeviceId,
                    DeviceType = src.ServiceRequest.Device.DeviceType,
                    ModelNumber = src.ServiceRequest.Device.ModelNumber
                }
            }));
        }
    }
}
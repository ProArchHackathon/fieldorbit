using System;
using ProArch.FieldOrbit.DataLayer.Extensions;
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
            MapServiceRequestViewModelToModel();

            //Models to View models
            MapWorkRequestModelToViewModel();
            MapServiceRequestModelToViewModel();
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
                    EmployeeId = src.ServiceRequest.ClosedBy == null ? 0 : src.ServiceRequest.ClosedBy.EmployeeId,
                },
                Type = src.ServiceRequest.Type,
                CreatedDate = src.ServiceRequest.CreatedDate,
                EndDate = src.ServiceRequest.EndDate,
                Location = src.ServiceRequest.Location,
                CreatedBy = new DomainModels.Employee()
                {
                    EmployeeId = src.ServiceRequest.CreatedBy == null ? 0 : src.ServiceRequest.CreatedBy.EmployeeId
                },
                Description = src.ServiceRequest.Description,
                DeviceOwner = src.ServiceRequest.DeviceOwner,
                ServiceRequestId = src.ServiceRequest.ServiceRequestId,
                RequestType = src.ServiceRequest.RequestType,
                ServiceType = src.ServiceRequest.ServiceType,
                StartDate = src.ServiceRequest.StartDate,
                Status = src.ServiceRequest.Status,
                Customer = new DomainModels.Customer()
                {
                    CustomerId = src.ServiceRequest.Customer == null ? 0 : src.ServiceRequest.Customer.CustomerId,
                    DeviceId = src.ServiceRequest.Customer == null ? string.Empty : src.ServiceRequest.Customer.DeviceId,
                    Active = src.ServiceRequest.Customer == null ? false : src.ServiceRequest.Customer.Active,
                    Address = new List<DomainModels.Address>()
                    {
                        new DomainModels.Address(){
                        Street = src.ServiceRequest.Customer.Address.FirstOrDefault() == null ? string.Empty : src.ServiceRequest.Customer.Address[0].Street,
                        City = src.ServiceRequest.Customer.Address.FirstOrDefault() == null ? string.Empty : src.ServiceRequest.Customer.Address[0].City,
                        State = src.ServiceRequest.Customer.Address.FirstOrDefault() == null ? string.Empty : src.ServiceRequest.Customer.Address[0].State,
                        Zip = src.ServiceRequest.Customer.Address == null ? string.Empty : src.ServiceRequest.Customer.Address[0].Zip,
                        }
                        },
                    Email = src.ServiceRequest.Customer == null ? string.Empty : src.ServiceRequest.Customer.Email,
                    AssetId = src.ServiceRequest.Customer == null ? string.Empty : src.ServiceRequest.Customer.AssetId,
                    Phone = src.ServiceRequest.Customer == null ? string.Empty : src.ServiceRequest.Customer.Phone,
                    SSN = src.ServiceRequest.Customer == null ? string.Empty : src.ServiceRequest.Customer.SSN,
                    Name = new DomainModels.Name()
                    {
                        FirstName = src.ServiceRequest.Customer.Name != null ? string.Empty : src.ServiceRequest.Customer.Name.FirstName,
                        MiddleName = src.ServiceRequest.Customer.Name != null ? string.Empty : src.ServiceRequest.Customer.Name.MiddleName,
                        LastName = src.ServiceRequest.Customer.Name != null ? string.Empty : src.ServiceRequest.Customer.Name.LastName
                    }
                },
                Device = new DomainModels.Device()
                {
                    DeviceId = src.ServiceRequest.Device == null ? string.Empty : src.ServiceRequest.Device.DeviceId,
                    DeviceType = src.ServiceRequest.Device == null ? string.Empty : src.ServiceRequest.Device.DeviceType,
                    ModelNumber = src.ServiceRequest.Device == null ? string.Empty : src.ServiceRequest.Device.ModelNumber
                }
            }));
        }

        public void MapServiceRequestViewModelToModel()
        {
            var serviceRequestMap = CreateMap<ViewModels.ServiceRequest, DomainModels.ServiceRequest>();
            serviceRequestMap.ForAllMembers(opt => opt.Ignore());
            serviceRequestMap.ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.DeviceOwner, opt => opt.MapFrom(src => src.DeviceOwner))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.RequestType, opt => opt.MapFrom(src => src.RequestType))
                .ForMember(dest => dest.ServiceRequestId, opt => opt.MapFrom(src => src.ServiceRequestId))
                .ForMember(dest => dest.ServiceType, opt => opt.MapFrom(src => src.ServiceType))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.ClosedBy, opt => opt.MapFrom(src => new DomainModels.Employee()
                {
                    EmployeeId = src.ClosedBy == null ? 0 : src.ClosedBy.EmployeeId,
                    Name = new DomainModels.Name()
                    {
                        FirstName = src.ClosedBy.Name == null ? string.Empty : src.ClosedBy.Name.FirstName,
                        MiddleName = src.ClosedBy.Name == null ? string.Empty : src.ClosedBy.Name.MiddleName,
                        LastName = src.ClosedBy.Name == null ? string.Empty : src.ClosedBy.Name.LastName
                    }
                }))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => new DomainModels.Employee()
                {
                    EmployeeId = src.CreatedBy == null ? 0 : src.CreatedBy.EmployeeId,
                    Name = new DomainModels.Name()
                    {
                        FirstName = src.CreatedBy.Name == null ? string.Empty : src.CreatedBy.Name.FirstName,
                        MiddleName = src.CreatedBy.Name == null ? string.Empty : src.CreatedBy.Name.MiddleName,
                        LastName = src.CreatedBy.Name == null ? string.Empty : src.CreatedBy.Name.LastName
                    }
                }))
                .ForMember(dest => dest.Device, opt => opt.MapFrom(src => new DomainModels.Device()
                {
                    DeviceId = src.Device == null ? string.Empty : src.Device.DeviceId,
                    DeviceType = src.Device == null ? string.Empty : src.Device.DeviceType,
                    ModelNumber = src.Device == null ? string.Empty : src.Device.ModelNumber
                
                }))
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => new DomainModels.Customer()
                {
                    Active = src.Customer == null ? false : src.Customer.Active,
                    CustomerId = src.Customer == null ? 0 : src.Customer.CustomerId,
                    Email = src.Customer == null ? string.Empty : src.Customer.Email,
                    AssetId = src.Customer == null ? string.Empty : src.Customer.AssetId,
                    DeviceId = src.Customer == null ? string.Empty : src.Customer.DeviceId,
                    Phone = src.Customer == null ? string.Empty : src.Customer.Phone,
                    SSN = src.Customer == null ? string.Empty : src.Customer.SSN,
                    Address = new List<DomainModels.Address>()
                    {

                        new DomainModels.Address(){
                        City = src.Customer.Address.FirstOrDefault() == null ? string.Empty : src.Customer.Address[0].City,
                        State = src.Customer.Address.FirstOrDefault() == null ? string.Empty : src.Customer.Address[0].State,
                        Street = src.Customer.Address.FirstOrDefault() == null ? string.Empty : src.Customer.Address[0].Street,
                        Zip = src.Customer.Address == null ? string.Empty : src.Customer.Address[0].Zip
                        }
                    },
                    Name = new DomainModels.Name()
                    {
                        FirstName = src.Customer.Name == null ? string.Empty : src.Customer.Name.FirstName,
                        MiddleName = src.Customer.Name == null ? string.Empty : src.Customer.Name.MiddleName,
                        LastName = src.Customer.Name == null ? string.Empty : src.Customer.Name.LastName
                    }
                }));
        }

        public void MapServiceRequestModelToViewModel()
        {
            var serviceRequestMap = CreateMap<DomainModels.ServiceRequest, ViewModels.ServiceRequest>();
            serviceRequestMap.ForAllMembers(opt => opt.Ignore());
            serviceRequestMap.ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.RequestType, opt => opt.MapFrom(src => src.RequestType))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.DeviceOwner, opt => opt.MapFrom(src => src.DeviceOwner))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ServiceRequestId, opt => opt.MapFrom(src => src.ServiceRequestId))
                .ForMember(dest => dest.ServiceType, opt => opt.MapFrom(src => src.ServiceType))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => new ViewModels.Employee()
                {
                    EmployeeId = src.CreatedBy == null ? 0 : src.CreatedBy.EmployeeId,
                    Name = new ViewModels.Name()
                    {
                        FirstName = src.CreatedBy.Name == null ? string.Empty : src.CreatedBy.Name.FirstName,
                        MiddleName = src.CreatedBy.Name == null ? string.Empty : src.CreatedBy.Name.MiddleName,
                        LastName = src.CreatedBy.Name == null ? string.Empty : src.CreatedBy.Name.LastName
                    }
                }))
                .ForMember(dest => dest.ClosedBy, opt => opt.MapFrom(src => new ViewModels.Employee()
                {
                    EmployeeId = src.ClosedBy == null ? 0 : src.ClosedBy.EmployeeId,
                    Name = new ViewModels.Name()
                    {
                        FirstName = src.ClosedBy == null ? string.Empty : src.ClosedBy.Name.FirstName,
                        MiddleName = src.ClosedBy == null ? string.Empty : src.ClosedBy.Name.MiddleName,
                        LastName = src.ClosedBy == null ? string.Empty : src.ClosedBy.Name.LastName
                    }
                }))
                .ForMember(dest => dest.Device, opt => opt.MapFrom(src => new ViewModels.Device()
                {
                    DeviceId = src.Device == null ? string.Empty : src.Device.DeviceId,
                    DeviceType = src.Device == null ? string.Empty : src.Device.DeviceType,
                    ModelNumber = src.Device == null ? string.Empty : src.Device.ModelNumber

                }))
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => new ViewModels.Customer()
                {
                    Active = src.Customer == null ? false : src.Customer.Active,
                    CustomerId = src.Customer == null ? 0 : src.Customer.CustomerId,
                    AssetId = src.Customer == null ? string.Empty : src.Customer.AssetId,
                    DeviceId = src.Customer == null ? string.Empty : src.Customer.DeviceId,
                    Email = src.Customer == null ? string.Empty : src.Customer.Email,
                    Phone = src.Customer == null ? string.Empty : src.Customer.Phone,
                    SSN = src.Customer == null ? string.Empty : src.Customer.SSN,
                    Address = new List<ViewModels.Address>()
                    {
                        new ViewModels.Address(){
                        City = src.Customer.Address.FirstOrDefault() == null ? string.Empty : src.Customer.Address[0].City,
                        State = src.Customer.Address.FirstOrDefault() == null ? string.Empty : src.Customer.Address[0].State,
                        Street = src.Customer.Address.FirstOrDefault() == null ? string.Empty : src.Customer.Address[0].Street,
                        Zip = src.Customer.Address == null ? string.Empty : src.Customer.Address[0].Zip
                        }
                    },
                    Name = new ViewModels.Name()
                    {
                        FirstName = src.Customer.Name == null ? string.Empty : src.Customer.Name.FirstName,
                        MiddleName = src.Customer.Name == null ? string.Empty : src.Customer.Name.MiddleName,
                        LastName = src.Customer.Name == null ? string.Empty : src.Customer.Name.LastName
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
                    EmployeeId = src.ServiceRequest.ClosedBy == null ? 0 : src.ServiceRequest.ClosedBy.EmployeeId,
                },
                CreatedBy = new ViewModels.Employee()
                {
                    EmployeeId = src.ServiceRequest.CreatedBy == null ? 0 : src.ServiceRequest.CreatedBy.EmployeeId,
                },
                CreatedDate = src.ServiceRequest.CreatedDate.HasValue ? src.ServiceRequest.CreatedDate : new DateTime(),
                Description = src.ServiceRequest.Description.ValidateData(),
                DeviceOwner = src.ServiceRequest.DeviceOwner.ValidateData(),
                EndDate = src.ServiceRequest.EndDate.HasValue ? src.ServiceRequest.EndDate : new DateTime(),
                Location = src.ServiceRequest.Location.ValidateData(),
                ServiceRequestId = src.ServiceRequest.ServiceRequestId,
                RequestType = src.ServiceRequest.RequestType.ValidateData(),
                Type = src.ServiceRequest.Type.ValidateData(),
                ServiceType = src.ServiceRequest.ServiceType.ValidateData(),
                StartDate = src.ServiceRequest.StartDate.HasValue ? src.ServiceRequest.StartDate : new DateTime(),
                Status = src.ServiceRequest.Status.ValidateData(),
                Customer = new ViewModels.Customer()
                {
                    CustomerId = src.ServiceRequest.Customer == null ? 0 : src.ServiceRequest.Customer.CustomerId,
                    Active = src.ServiceRequest.Customer == null ? false : src.ServiceRequest.Customer.Active,
                    AssetId = src.ServiceRequest.Customer == null ? string.Empty : src.ServiceRequest.Customer.AssetId,
                    DeviceId = src.ServiceRequest.Customer == null ? string.Empty : src.ServiceRequest.Customer.DeviceId,
                    Address = new List<ViewModels.Address>()
                    {
                        new ViewModels.Address(){
                        Street = src.ServiceRequest.Customer.Address.FirstOrDefault() == null ? string.Empty : src.ServiceRequest.Customer.Address[0].Street,
                        City = src.ServiceRequest.Customer.Address.FirstOrDefault() == null ? string.Empty : src.ServiceRequest.Customer.Address[0].City,
                        State = src.ServiceRequest.Customer.Address.FirstOrDefault() == null ? string.Empty : src.ServiceRequest.Customer.Address[0].State,
                        Zip = src.ServiceRequest.Customer.Address == null ? string.Empty : src.ServiceRequest.Customer.Address[0].Zip,
                        }
                    },
                    Email = src.ServiceRequest.Customer == null ? string.Empty : src.ServiceRequest.Customer.Email,
                    Phone = src.ServiceRequest.Customer == null ? string.Empty : src.ServiceRequest.Customer.Phone,
                    SSN = src.ServiceRequest.Customer == null ? string.Empty : src.ServiceRequest.Customer.SSN,
                    Name = new ViewModels.Name()
                    {
                        FirstName = src.ServiceRequest.Customer.Name == null ? string.Empty : src.ServiceRequest.Customer.Name.FirstName,
                        MiddleName = src.ServiceRequest.Customer.Name == null ? string.Empty : src.ServiceRequest.Customer.Name.MiddleName,
                        LastName = src.ServiceRequest.Customer.Name == null ? string.Empty : src.ServiceRequest.Customer.Name.LastName
                    }
                },
                Device = new ViewModels.Device()
                {
                    DeviceId = src.ServiceRequest.Device == null ? string.Empty : src.ServiceRequest.Device.DeviceId,
                    DeviceType = src.ServiceRequest.Device == null ? string.Empty : src.ServiceRequest.Device.DeviceType,
                    ModelNumber = src.ServiceRequest.Device == null ? string.Empty : src.ServiceRequest.Device.ModelNumber
                }
            }));
        }
    }
}
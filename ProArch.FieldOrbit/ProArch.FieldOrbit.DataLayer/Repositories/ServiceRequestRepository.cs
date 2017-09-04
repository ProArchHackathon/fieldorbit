using System;
using MongoDB.Bson;
using ProArch.FieldOrbit.DataContracts.Interfaces;
using ProArch.FieldOrbit.Models;
using System.Collections.Generic;
using ProArch.FieldOrbit.DataLayer.Extensions;

namespace ProArch.FieldOrbit.DataLayer.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class ServiceRequestRepository : IServiceRequestRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceRequest"></param>
        /// <returns></returns>
        public bool CreateServiceRequest(ServiceRequest serviceRequest)
        {
            return new MongoRepository().Create(CreateRequest(serviceRequest), "servicerequest");
        }

        private BsonDocument CreateRequest(ServiceRequest serviceRequest)
        {
            var document = new BsonDocument
            {
                {"servicerequestid", new MongoRepository().GetCount("servicerequest")},
                { "createdby",serviceRequest.CreatedBy==null? new BsonDocument() : new BsonDocument
                    {
                        { "employeeid", serviceRequest.CreatedBy.EmployeeId }
                    }
                },
                { "deviceowner",serviceRequest.DeviceOwner.ValidateData()},
                { "description",serviceRequest.Description.ValidateData()},
                {"createddate", serviceRequest.CreatedDate.HasValue? serviceRequest.CreatedDate:new DateTime()},
                {"startdate" ,serviceRequest.StartDate.HasValue?serviceRequest.StartDate:new DateTime()},
                {"servicetype",serviceRequest.ServiceType.ValidateData()},
                {"requesttype", serviceRequest.RequestType.ValidateData()},
                {"customer",serviceRequest.Customer==null? new BsonDocument() : new BsonDocument
                    {
                        { "customerid", serviceRequest.Customer.CustomerId }
                    }
                },
                { "location",serviceRequest.Location.ValidateData() },
                { "enddate",serviceRequest.EndDate.HasValue? serviceRequest.EndDate: new DateTime() },
                { "closedby", serviceRequest.ClosedBy==null? new BsonDocument() : new BsonDocument
                    {
                        {"employeeid",serviceRequest.ClosedBy.EmployeeId },
                        {"name", new BsonDocument
                            {
                                {"firstname",serviceRequest.ClosedBy.Name.FirstName.ValidateData() },
                                {"middlename",serviceRequest.ClosedBy.Name.MiddleName.ValidateData() },
                                {"lastname",serviceRequest.ClosedBy.Name.LastName.ValidateData() }
                            }
                        }
                    }
                },
                { "status",serviceRequest.Status.ValidateData() }
            };
            return document;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceRequestId"></param>
        /// <returns></returns>
        public ServiceRequest GetServiceRequestBySRNumber(int serviceRequestId)
        {
            return new MongoRepository().GetServiceRequestBySRNumber(serviceRequestId, "servicerequest");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceRequest"></param>
        /// <returns></returns>
        public bool UpdateServiceRequest(ServiceRequest serviceRequest)
        {
            var document = new BsonDocument
            {
                {"servicerequestid", serviceRequest.ServiceRequestId},
                { "createdby",serviceRequest.CreatedBy==null? new BsonDocument() : new BsonDocument
                    {
                        { "employeeid", serviceRequest.CreatedBy.EmployeeId }
                    }
                },
                { "deviceowner",serviceRequest.DeviceOwner.ValidateData()},
                { "description",serviceRequest.Description.ValidateData()},
                {"createddate", serviceRequest.CreatedDate.HasValue? serviceRequest.CreatedDate:new DateTime()},
                {"startdate" ,serviceRequest.StartDate.HasValue?serviceRequest.StartDate:new DateTime()},
                {"servicetype",serviceRequest.ServiceType.ValidateData()},
                {"requesttype", serviceRequest.RequestType.ValidateData()},
                {"customer",serviceRequest.Customer==null? new BsonDocument() : new BsonDocument
                    {
                        { "customerid", serviceRequest.Customer.CustomerId }
                    }
                },
                { "location",serviceRequest.Location },
                { "enddate",serviceRequest.EndDate.HasValue? serviceRequest.EndDate: new DateTime() },
                { "closedby", serviceRequest.ClosedBy==null? new BsonDocument() : new BsonDocument
                    {
                        {"employeeid",serviceRequest.ClosedBy.EmployeeId },
                        {"name", new BsonDocument
                            {
                                {"firstname",serviceRequest.ClosedBy.Name.FirstName.ValidateData() },
                                {"middlename",serviceRequest.ClosedBy.Name.MiddleName.ValidateData() },
                                {"lastname",serviceRequest.ClosedBy.Name.LastName.ValidateData() }
                            }
                        }
                    }
                },
                { "status",serviceRequest.Status.ValidateData() }
            };

            return new MongoRepository().UpdateServiceRequest(document, "servicerequest");
        }

        public IEnumerable<ServiceRequest> GetAllServiceRequests()
        {
            return new MongoRepository().GetAllServiceRequests("servicerequest");
        }
    }
}

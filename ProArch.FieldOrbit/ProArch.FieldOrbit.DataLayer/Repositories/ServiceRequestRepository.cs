using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using ProArch.FieldOrbit.DataContracts.Interfaces;
using ProArch.FieldOrbit.Models;

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
                {"createddate", serviceRequest.CreatedDate},
                {"startdate" ,serviceRequest.StartDate},
                {"servicetype",serviceRequest.ServiceType.ToString()},
                {"requesttype", serviceRequest.RequestType.ToString()},
                {"customer",serviceRequest.Customer==null? new BsonDocument() : new BsonDocument
                    {
                        { "customerid", serviceRequest.Customer.CustomerId }
                    }
                },
                { "location",serviceRequest.Location },
                { "enddate",serviceRequest.EndDate.HasValue? serviceRequest.EndDate: null },
                { "closedby", serviceRequest.ClosedBy==null? new BsonDocument() : new BsonDocument
                    {
                        {"employeeid",serviceRequest.ClosedBy.EmployeeId },
                        {"name", new BsonDocument
                            {
                                {"firstname",serviceRequest.ClosedBy.Name.FirstName },
                                {"middlename",serviceRequest.ClosedBy.Name.MiddleName },
                                {"lastname",serviceRequest.ClosedBy.Name.LastName }
                            }
                        }
                    }
                },
                { "status",serviceRequest.Status.ToString() }
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
                {"servicerequestid", new MongoRepository().GetCount("servicerequest")},
                {"createddate", serviceRequest.CreatedDate},
                {"startdate" ,serviceRequest.StartDate},
                {"servicetype",serviceRequest.ServiceType.ToString()},
                {"requesttype", serviceRequest.RequestType.ToString()},
                {"customer",serviceRequest.Customer==null? new BsonDocument() : new BsonDocument
                    {
                        { "customerid", serviceRequest.Customer.CustomerId }
                    }
                },
                { "location",serviceRequest.Location },
                { "enddate",serviceRequest.EndDate.HasValue? serviceRequest.EndDate: null },
                { "closedby", serviceRequest.ClosedBy==null? new BsonDocument() : new BsonDocument
                    {
                        {"employeeid",serviceRequest.ClosedBy.EmployeeId },
                        {"name", new BsonDocument
                            {
                                {"firstname",serviceRequest.ClosedBy.Name.FirstName },
                                {"middlename",serviceRequest.ClosedBy.Name.MiddleName },
                                {"lastname",serviceRequest.ClosedBy.Name.LastName }
                            }
                        }
                    }
                },
                { "status",serviceRequest.Status.ToString() }
            };

            return new MongoRepository().UpdateServiceRequest(document, "servicerequest");
        }

        public IEnumerable<ServiceRequest> GetAllServiceRequests()
        {
            return new MongoRepository().GetAllServiceRequests("servicerequest");
        }
    }
}

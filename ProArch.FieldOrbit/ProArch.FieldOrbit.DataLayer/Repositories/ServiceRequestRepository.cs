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
            return new MongoRepository().Create(GetServiceRequest(serviceRequest), "servicerequest");
        }

        private BsonDocument GetServiceRequest(ServiceRequest serviceRequest)
        {
            var document = new BsonDocument
            {
                {"servicerequestid", new MongoRepository().GetCount("servicerequest")},
                {"createddate", serviceRequest.CreatedDate},
                {"startdate" ,serviceRequest.StartDate},
                {"servicetype",serviceRequest.ServiceType.ToString()},
                {"requesttype",serviceRequest.RequestType.ToString()},
                {"customer", new BsonDocument
                    {
                        { "customerid" ,serviceRequest.Customer.CustomerId }
                    }
                },
                { "location",serviceRequest.Location },
                { "enddate",serviceRequest.EndDate.HasValue? serviceRequest.EndDate: null },
                { "closedby", new BsonDocument
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
        /// <param name="SRNumber"></param>
        /// <returns></returns>
        public bool UpdateServiceRequest(ServiceRequest serviceRequest, int SRNumber)
        {
            var deviceInformation = new BsonDocument
            {
                {"deviceid", serviceRequest.Device.DeviceId },
                {"devicetype", serviceRequest.Device.DeviceType.ToString()},
                {"serialno", serviceRequest.Device.ModelNumber }
            };

            var customerInformation = new BsonDocument
            {
                { "customerid" ,serviceRequest.Customer.CustomerId }
            };


            var document = new BsonDocument
            {
                {"servicerequestid", SRNumber },
                {"createddate", serviceRequest.CreatedDate},
                {"servicetype",serviceRequest.ServiceType.ToString()},
                {"requesttype",serviceRequest.RequestType.ToString()},
                {"customer", customerInformation },
                {"device", deviceInformation },
                { "location",serviceRequest.Location },
                { "closedate",serviceRequest.EndDate.HasValue? serviceRequest.EndDate: null },
                { "closedby",serviceRequest.ClosedBy.EmployeeId },
                { "status",serviceRequest.Status.ToString() }
            };

            //new MongoRepository().UpdateServiceRequest(document, "servicerequest", SRNumber);
            return true;
        }

        public IEnumerable<ServiceRequest> GetAllServiceRequests()
        {
            throw new NotImplementedException();
        }
    }
}

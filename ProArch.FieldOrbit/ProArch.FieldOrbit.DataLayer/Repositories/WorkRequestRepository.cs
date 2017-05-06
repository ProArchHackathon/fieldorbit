using ProArch.FieldOrbit.DataContracts.Interfaces;
using ProArch.FieldOrbit.Models;
using System;
using MongoDB.Bson;

namespace ProArch.FieldOrbit.DataLayer.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class WorkRequestRepository : IWorkRequestRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workRequest"></param>
        /// <returns></returns>
        public bool CreateWorkRequest(WorkRequest workRequest)
        {
            return new MongoRepository().Create(GetWorkRequestDocument(workRequest), "workorder");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="WRNumber"></param>
        /// <returns></returns>
        public WorkRequest GetWorkRequestByID(int WRNumber)
        {
            return new MongoRepository().GetWorkRequestById(WRNumber, "workorder");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workRequest"></param>
        /// <returns></returns>
        public bool UpdateWorkRequest(WorkRequest workRequest)
        {
            var document = new BsonDocument
            {
                {"workorderid", workRequest.WorkRequestId },
                {"description", workRequest.Description},
                {"startdate", workRequest.StartDate},
                {"enddate", workRequest.EndDate.Value},
                {"servicerequest", new BsonDocument
                    {
                        { "createddate", workRequest.ServiceRequest.CreatedDate },
                        { "startdate", workRequest.ServiceRequest.StartDate },
                        { "servicetype", workRequest.ServiceRequest.ServiceType.ToString() },
                        { "requesttype", workRequest.ServiceRequest.RequestType.ToString() },
                        { "customer", new BsonDocument { { "customerid", workRequest.ServiceRequest.Customer.CustomerId } }},
                        { "device", new BsonDocument
                            {
                                { "deviceid", workRequest.ServiceRequest.Device.DeviceId },
                                { "devicetype", workRequest.ServiceRequest.Device.DeviceType.ToString() },
                                { "serialno", workRequest.ServiceRequest.Device.ModelNumber }
                            }
                        },
                        { "location", workRequest.ServiceRequest.Location },
                        { "closedate", workRequest.ServiceRequest.EndDate.Value },
                        { "closedby", new BsonDocument
                            {
                                {"employeeid", workRequest.ServiceRequest.ClosedBy.EmployeeId}
                            }
                        },
                        { "status", workRequest.ServiceRequest.Status.ToString() }
                    }
                },
                { "status", workRequest.Status }
            };

            return new MongoRepository().UpdateWorkRequest(document, "workorder");
        }

        internal BsonDocument GetWorkRequestDocument(WorkRequest workRequest)
        {
            return new BsonDocument
            {
                {"workorderid", new MongoRepository().GetCount("workorder") },
                {"description", workRequest.Description},
                {"startdate", workRequest.StartDate},
                {"enddate", workRequest.EndDate.Value},
                {"servicerequest", new BsonDocument
                    {
                        { "createddate", workRequest.ServiceRequest.CreatedDate },
                        { "startdate", workRequest.ServiceRequest.StartDate },
                        { "servicetype", workRequest.ServiceRequest.ServiceType.ToString() },
                        { "requesttype", workRequest.ServiceRequest.RequestType.ToString() },
                        { "customer", new BsonDocument { { "customerid", workRequest.ServiceRequest.Customer.CustomerId } }},
                        { "device", new BsonDocument
                            {
                                { "deviceid", workRequest.ServiceRequest.Device.DeviceId },
                                { "devicetype", workRequest.ServiceRequest.Device.DeviceType.ToString() },
                                { "serialno", workRequest.ServiceRequest.Device.ModelNumber }
                            }
                        },
                        { "location", workRequest.ServiceRequest.Location },
                        { "closedate", workRequest.ServiceRequest.EndDate.Value },
                        { "closedby", new BsonDocument
                            {
                                {"employeeid", workRequest.ServiceRequest.ClosedBy.EmployeeId}
                            }
                        },
                        { "status", workRequest.ServiceRequest.Status.ToString() }
                    }
                },
                { "status", workRequest.Status }
            };
        }
    }
}

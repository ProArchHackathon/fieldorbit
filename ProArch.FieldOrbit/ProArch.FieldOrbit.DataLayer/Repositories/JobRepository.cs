using ProArch.FieldOrbit.DataContracts.Interfaces;
using ProArch.FieldOrbit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using MongoDB.Bson;
using ProArch.FieldOrbit.DataLayer.Extensions;

namespace ProArch.FieldOrbit.DataLayer.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class JobRepository : IJobRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public bool CreateJob(Job job)
        {
            return new MongoRepository().Create(CreateJobRequest(job), "job");
        }

        private BsonDocument CreateJobRequest(Job job)
        {
            var customer = new BsonDocument();
            var device = new BsonDocument();
            var workRequestDocument = new BsonDocument();
            var employeeDocument = new BsonDocument();


            if (job.Employee != null)
            {
                employeeDocument = new BsonDocument
                        {
                            {"employeeid", job.Employee.EmployeeId },
                            {"name", job.Employee.Name == null ? new BsonDocument() : new BsonDocument
                                {
                                    {"firstname", job.Employee.Name.FirstName },
                                    {"middlename", job.Employee.Name.MiddleName },
                                    {"lastname", job.Employee.Name.LastName }
                                }
                            },
                            {"phone",job.Employee.Phone==null?string.Empty: job.Employee.Phone },
                            {"email", job.Employee.Email ==null?string.Empty: job.Employee.Email },
                            {"active", job.Employee.Active },
                            {"voicecalluserid",job.Employee.VoiceCallUserId==null?string.Empty: job.Employee.VoiceCallUserId }
                        };
            }

            if (job.WorkRequest != null)
            {
                if (job.WorkRequest.ServiceRequest.Customer != null)
                {
                    customer = new BsonDocument
                    {
                        {"customerid", job.WorkRequest.ServiceRequest.Customer.CustomerId },
                        {"deviceid",job.WorkRequest.ServiceRequest.Customer.DeviceId},
                        {"assetid",job.WorkRequest.ServiceRequest.Customer.AssetId},
                        {"name", (job.WorkRequest.ServiceRequest.Customer==null||job.WorkRequest.ServiceRequest.Customer.Name==null)?new BsonDocument(): new BsonDocument
                            {
                                {"firstname", job.WorkRequest.ServiceRequest.Customer.Name.FirstName },
                                {"middlename", job.WorkRequest.ServiceRequest.Customer.Name.MiddleName },
                                {"lastname", job.WorkRequest.ServiceRequest.Customer.Name.LastName }
                            }
                        },
                        {"email",job.WorkRequest.ServiceRequest.Customer.Email==null?string.Empty: job.WorkRequest.ServiceRequest.Customer.Email },
                        {"phone",job.WorkRequest.ServiceRequest.Customer.Phone==null?string.Empty: job.WorkRequest.ServiceRequest.Customer.Phone }
                    };
                }

                if (job.WorkRequest.ServiceRequest.Device != null)
                {
                    device = new BsonDocument
                    {
                      { "deviceid",job.WorkRequest.ServiceRequest.Device.DeviceId==null?string.Empty: job.WorkRequest.ServiceRequest.Device.DeviceId },
                      { "devicetype",job.WorkRequest.ServiceRequest.Device.DeviceType==null?string.Empty: job.WorkRequest.ServiceRequest.Device.DeviceType },
                      { "serialno", job.WorkRequest.ServiceRequest.Device.ModelNumber }
                    };
                }

                workRequestDocument = new BsonDocument
                {
                    {"workorderid", job.WorkRequest.WorkRequestId },
                    {"description", job.WorkRequest.Description.ValidateData() },
                    {"startdate", job.WorkRequest.StartDate},
                    {"enddate", job.WorkRequest.EndDate.Value},
                    { "status", job.Status.ToString() },
                    {"servicerequest", new BsonDocument
                        {
                            { "createddate", job.WorkRequest.ServiceRequest.CreatedDate },
                              { "createdBy",job.WorkRequest.ServiceRequest.CreatedBy==null? new BsonDocument() : new BsonDocument
                                 {
                                     { "employeeid", job.WorkRequest.ServiceRequest.CreatedBy.EmployeeId }
                                 }
                              },
                            { "deviceOwner",job.WorkRequest.ServiceRequest.DeviceOwner.ToString()},
                            { "description",job.WorkRequest.ServiceRequest.Description.ToString()},
                            { "startdate", job.WorkRequest.ServiceRequest.StartDate },
                            { "servicetype", job.WorkRequest.ServiceRequest.ServiceType.ToString() },
                            { "requesttype", job.WorkRequest.ServiceRequest.RequestType.ToString() },
                            { "device",job.WorkRequest.ServiceRequest.Device==null? new BsonDocument(): new BsonDocument
                                {
                                    { "deviceid", job.WorkRequest.ServiceRequest.Device.DeviceId.ValidateData() },
                                    { "devicetype", job.WorkRequest.ServiceRequest.Device.DeviceType.ValidateData() },
                                    { "serialno", job.WorkRequest.ServiceRequest.Device.ModelNumber }
                                }
                            },
                            { "location", job.WorkRequest.ServiceRequest.Location.ValidateData() },
                            { "closedate", job.WorkRequest.ServiceRequest.EndDate.Value },
                            { "closedby",job.WorkRequest.ServiceRequest.ClosedBy==null?new BsonDocument(): new BsonDocument
                                {
                                    {"employeeid", job.WorkRequest.ServiceRequest.ClosedBy.EmployeeId}
                                }
                            },
                            { "status", job.WorkRequest.ServiceRequest.Status.ToString() },
                            {"customer", customer},
                        }
                    }
                };
            }

            return new BsonDocument
            {
                { "jobid", new MongoRepository().GetCount("job")},
                { "status", job.Status.ValidateData() },
                { "priority", job.Priority.ValidateData() },
                { "jobdescription", job.JobDescription.ValidateData() },
                { "starttime", job.StartTime },
                { "endtime", job.EndTime },
                { "comments", job.Comments.ValidateData() },
                { "observations", job.Observations.ValidateData() },
                { "workrequest", workRequestDocument},
                {"employee", employeeDocument }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        public Job GetJobByID(int JobId)
        {
            return new MongoRepository().GetJobByID(JobId, "job");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        public VRJob GetVRJobByID(int JobId)
        {
            return new MongoRepository().GetVRJobByID(JobId, "job");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public List<Job> GetUserJob(int employeeID)
        {
            return new MongoRepository().GetJobByEmployee(employeeID, "job");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public bool UpdateJob(Job job)
        {
            var document = new BsonDocument
            {
                { "jobid", job.JobId},
                { "status", job.Status.ToString() },
                { "priority", job.Priority.ToString() },
                { "jobdescription", job.JobDescription },
                { "starttime", job.StartTime },
                { "endtime", job.EndTime },
                { "comments", job.Comments },
                { "observations", job.Observations }
            };
            return new MongoRepository().UpdateJobRequest(document, "job", false);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JobID"></param>
        /// <param name="Status"></param>
        /// <param name="Comments"></param>
        /// <param name="Observations"></param>
        /// <returns></returns>
        public bool UpdateJob(int JobID, string Status, string Comments, string Observations)
        {
            var document = new BsonDocument
            {
                { "jobid", JobID},
                { "status", Status.ToString() },
                { "comments", Comments },
                { "observations", Observations }
            };
            return new MongoRepository().UpdateJobRequest(document, "job", true);

        }

        public bool EnterTimeSheet(Job job, Timesheet timeSheet)
        {
            return new MongoRepository().EnterTimeSheet(job, timeSheet);
        }
    }
}

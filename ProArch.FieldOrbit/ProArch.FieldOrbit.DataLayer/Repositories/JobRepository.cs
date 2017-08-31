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
            var serviceRequestDocument = new BsonDocument();
            var employeeDocument = new BsonDocument();


            if (job.Employee != null)
            {
                employeeDocument = new BsonDocument
                        {
                            {"employeeid", job.ServiceRequest.Customer.CustomerId },
                            {"name", job.Employee.Name == null ? new BsonDocument() : new BsonDocument
                                {
                                    {"firstname", job.Employee.Name.FirstName.ValidateData() },
                                    {"middlename", job.Employee.Name.MiddleName.ValidateData()},
                                    {"lastname", job.Employee.Name.LastName.ValidateData()}
                                }
                            },
                            {"phone",job.Employee.Phone.ValidateData() },
                            {"email", job.Employee.Email.ValidateData() },
                            {"active", job.Employee.Active },
                            {"voicecalluserid",job.Employee.VoiceCallUserId.ValidateData() }
                        };
            }

            if (job.ServiceRequest != null)
            {
                if (job.ServiceRequest.Customer != null)
                {
                    customer = new BsonDocument
                    {
                        {"customerid", job.ServiceRequest.Customer.CustomerId },
                        {"deviceid",job.ServiceRequest.Customer.DeviceId.ValidateData()},
                        {"assetid",job.ServiceRequest.Customer.AssetId},
                        {"name", (job.ServiceRequest.Customer==null||job.ServiceRequest.Customer.Name==null)?new BsonDocument(): new BsonDocument
                            {
                                {"firstname", job.ServiceRequest.Customer.Name.FirstName.ValidateData()},
                                {"middlename", job.ServiceRequest.Customer.Name.MiddleName.ValidateData()},
                                {"lastname", job.ServiceRequest.Customer.Name.LastName.ValidateData()}
                            }
                        },
                        {"email",job.ServiceRequest.Customer.Email.ValidateData() },
                        {"phone",job.ServiceRequest.Customer.Phone.ValidateData() }
                    };
                }

                if (job.ServiceRequest.Device != null)
                {
                    device = new BsonDocument
                    {
                      { "deviceid",job.ServiceRequest.Device.DeviceId.ValidateData() },
                      { "devicetype",job.ServiceRequest.Device.DeviceType.ValidateData() },
                      { "serialno", job.ServiceRequest.Device.ModelNumber.ValidateData()}
                    };
                }

                serviceRequestDocument = new BsonDocument
                {
                    { "createddate", job.ServiceRequest.CreatedDate.HasValue?job.ServiceRequest.CreatedDate:new DateTime() },
                        { "createdBy",job.ServiceRequest.CreatedBy==null? new BsonDocument() : new BsonDocument
                            {
                                { "employeeid", job.ServiceRequest.CreatedBy.EmployeeId }
                            }
                        },
                    { "deviceOwner",job.ServiceRequest.DeviceOwner.ValidateData()},
                    { "description",job.ServiceRequest.Description.ValidateData()},
                    { "startdate", job.ServiceRequest.StartDate.HasValue?job.ServiceRequest.StartDate:new DateTime() },
                    { "servicetype", job.ServiceRequest.ServiceType.ValidateData() },
                    { "requesttype", job.ServiceRequest.RequestType.ValidateData() },
                    { "device",job.ServiceRequest.Device==null? new BsonDocument(): new BsonDocument
                        {
                            { "deviceid", job.ServiceRequest.Device.DeviceId.ValidateData() },
                            { "devicetype", job.ServiceRequest.Device.DeviceType.ValidateData() },
                            { "serialno", job.ServiceRequest.Device.ModelNumber.ValidateData() }
                        }
                    },
                    { "location", job.ServiceRequest.Location.ValidateData() },
                    { "closedate", job.ServiceRequest.EndDate },
                    { "closedby",job.ServiceRequest.ClosedBy==null?new BsonDocument(): new BsonDocument
                        {
                            {"employeeid", job.ServiceRequest.ClosedBy.EmployeeId}
                        }
                    },
                    { "status", job.ServiceRequest.Status.ToString() },
                    {"customer", customer},

                };
            }

            return new BsonDocument
            {
                { "jobid", new MongoRepository().GetCount("job")},
                { "status", job.Status.ValidateData() },
                { "priority", job.Priority.ValidateData() },
                { "jobdescription", job.JobDescription.ValidateData() },
                { "starttime", job.StartTime.HasValue?job.StartTime:new DateTime() },
                { "endtime", job.EndTime.HasValue?job.EndTime:new DateTime() },
                { "comments", job.Comments.ValidateData() },
                { "observations", job.Observations.ValidateData() },
                { "servicerequest", serviceRequestDocument},
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

        public List<Job> GetAllJobs()
        {
            return new MongoRepository().GetJobs("job");
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
                { "status", job.Status.ValidateData() },
                { "priority", job.Priority.ValidateData() },
                { "jobdescription", job.JobDescription.ValidateData() },
                { "starttime", job.StartTime.HasValue?job.StartTime:new DateTime() },
                { "endtime", job.EndTime.HasValue?job.EndTime:new DateTime() },
                { "comments", job.Comments.ValidateData() },
                { "observations", job.Observations.ValidateData() }
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
                { "status", Status.ValidateData() },
                { "comments", Comments.ValidateData() },
                { "observations", Observations.ValidateData() }
            };
            return new MongoRepository().UpdateJobRequest(document, "job", true);

        }

        public bool EnterTimeSheet(Job job, Timesheet timeSheet)
        {
            return new MongoRepository().EnterTimeSheet(job, timeSheet);
        }
    }
}

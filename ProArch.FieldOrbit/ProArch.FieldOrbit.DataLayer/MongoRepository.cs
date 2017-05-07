using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using ProArch.FieldOrbit.DataLayer.Common;
using ProArch.FieldOrbit.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProArch.FieldOrbit.DataLayer
{
    public class MongoRepository
    {
        /// <summary>
        /// This is only for test purpose we remove once we started coding.
        /// </summary>
        /// <returns></returns>

        public IMongoClient _client;
        public IMongoDatabase _database;

        public bool IsConnected()
        {
            _client = new MongoClient(Utilities.MongoServerUrl);
            _database = _client.GetDatabase(Utilities.MongoServerDB);
            return true;
        }

        public long GetCount(string collectionName)
        {
            IMongoClient _client = new MongoClient(Utilities.MongoServerUrl);
            IMongoDatabase _database = _client.GetDatabase(Utilities.MongoServerDB);
            return _database.GetCollection<BsonDocument>(collectionName).Count(new BsonDocument()) + 1;
        }

        public Device GetDeviceById(string deviceId, string collectionName)
        {
            IMongoClient _client = new MongoClient(Utilities.MongoServerUrl);
            IMongoDatabase _database = _client.GetDatabase(Utilities.MongoServerDB);
            return _database.GetCollection<Device>(collectionName).Find(dev => dev.DeviceId == deviceId).FirstOrDefault();
        }

        public bool Create(BsonDocument doc, string collectionName)
        {
            IMongoClient _client = new MongoClient(Utilities.MongoServerUrl);
            IMongoDatabase _database = _client.GetDatabase(Utilities.MongoServerDB);
            var collection = _database.GetCollection<BsonDocument>(collectionName);
            collection.InsertOne(doc);
            return true;
        }

        public WorkRequest GetWorkRequestById(int workRequestId, string collectionName)
        {
            IMongoClient _client = new MongoClient(Utilities.MongoServerUrl);
            IMongoDatabase _database = _client.GetDatabase(Utilities.MongoServerDB);
            return _database.GetCollection<WorkRequest>(collectionName).Find(id => id.WorkRequestId == workRequestId).FirstOrDefault();
        }

        public List<Job> GetCustomerDevices(int customerId, string collectionName)
        {
            IMongoClient _client = new MongoClient(Utilities.MongoServerUrl);
            IMongoDatabase _database = _client.GetDatabase(Utilities.MongoServerDB);
            var collection = _database.GetCollection<Job>(collectionName);
            var filter1 = Builders<Job>.Filter.Eq("workrequest.servicerequest.customer.customerid", customerId);
            return collection.Find(filter1).ToList();
        }

        public IEnumerable<ServiceRequest> GetAllServiceRequests(string collectionName)
        {
            IMongoClient _client = new MongoClient(Utilities.MongoServerUrl);
            IMongoDatabase _database = _client.GetDatabase(Utilities.MongoServerDB);
            return _database.GetCollection<ServiceRequest>(collectionName).AsQueryable().ToList();
        }

        public ServiceRequest GetServiceRequestBySRNumber(int serviceRequestId, string collectionName)
        {
            IMongoClient _client = new MongoClient(Utilities.MongoServerUrl);
            IMongoDatabase _database = _client.GetDatabase(Utilities.MongoServerDB);
            return _database.GetCollection<ServiceRequest>(collectionName).Find(id => id.ServiceRequestId == serviceRequestId).FirstOrDefault();
        }

        public bool UpdateServiceRequest(BsonDocument doc, string collectionName)
        {
            IMongoClient _client = new MongoClient(Utilities.MongoServerUrl);
            IMongoDatabase _database = _client.GetDatabase(Utilities.MongoServerDB);
            var collection = _database.GetCollection<ServiceRequest>(collectionName);

            var serviceRequest = BsonSerializer.Deserialize<ServiceRequest>(doc);
            var filter = Builders<ServiceRequest>.Filter.Eq("servicerequestid", serviceRequest.ServiceRequestId);
            var update = Builders<ServiceRequest>.Update.Set("location", serviceRequest.Location).
                                                         Set("startdate", serviceRequest.StartDate).
                                                         Set("servicetype", serviceRequest.ServiceType).
                                                         Set("requesttype", serviceRequest.RequestType).
                                                         Set("enddate", serviceRequest.EndDate).
                                                         Set("status", serviceRequest.Status).
                                                         Set("customer.customerid", serviceRequest.Customer.CustomerId);
            collection.UpdateOne(filter, update);
            return true;
        }

        public IEnumerable<Device> GetAllDevices(string collectionName)
        {
            IMongoClient _client = new MongoClient(Utilities.MongoServerUrl);
            IMongoDatabase _database = _client.GetDatabase(Utilities.MongoServerDB);
            return _database.GetCollection<Device>(collectionName).AsQueryable().ToList();            
        }

        public bool UpdateWorkRequest(BsonDocument doc, string collectionName)
        {
            IMongoClient _client = new MongoClient(Utilities.MongoServerUrl);
            IMongoDatabase _database = _client.GetDatabase(Utilities.MongoServerDB);
            var collection = _database.GetCollection<ServiceRequest>(collectionName);

            WorkRequest workRequest = BsonSerializer.Deserialize<WorkRequest>(doc);
            var filter = Builders<ServiceRequest>.Filter.Eq("workorderid", workRequest.WorkRequestId);
            var update = Builders<ServiceRequest>.Update.Set("description", workRequest.Description).
                                                         Set("startdate", workRequest.StartDate).
                                                         Set("enddate", workRequest.EndDate.HasValue ? workRequest.EndDate : null).
                                                         Set("status", workRequest.Status);
            collection.UpdateOne(filter, update);
            return true;
        }

        public bool UpdateJobRequest(BsonDocument doc, string collectionName, bool isForComments)
        {
            IMongoClient _client = new MongoClient(Utilities.MongoServerUrl);
            IMongoDatabase _database = _client.GetDatabase(Utilities.MongoServerDB);
            var collection = _database.GetCollection<Job>(collectionName);

            Job job = BsonSerializer.Deserialize<Job>(doc);
            var filter = Builders<Job>.Filter.Eq("jobid", job.JobId);
            var update = Builders<Job>.Update.Set("status", job.Status).
                                                         Set("priority", job.Priority).
                                                         Set("starttime", job.StartTime).
                                                         Set("endtime", job.EndTime.HasValue ? job.EndTime : null);
            if (isForComments)
            {
                update.Set("comments", job.Comments).
                    Set("observations", job.Observations);
            }
            collection.UpdateOne(filter, update);
            return true;
        }

        public Job GetJobByID(int jobId, string collectionName)
        {
            IMongoClient _client = new MongoClient(Utilities.MongoServerUrl);
            IMongoDatabase _database = _client.GetDatabase(Utilities.MongoServerDB);
            return _database.GetCollection<Job>(collectionName).Find(id => id.JobId == jobId).FirstOrDefault();
        }

        public DeviceExpert GetExpert(string deviceId, string collectionName)
        {
            IMongoClient _client = new MongoClient(Utilities.MongoServerUrl);
            IMongoDatabase _database = _client.GetDatabase(Utilities.MongoServerDB);
            var collection = _database.GetCollection<DeviceExpert>(collectionName);
            var filter = Builders<DeviceExpert>.Filter.Eq("device.deviceid", deviceId);
            return collection.Find(filter).SingleOrDefault();
        }

        public string GetVideoPath(string deviceId, string videoType, string collectionName)
        {
            IMongoClient _client = new MongoClient(Utilities.MongoServerUrl);
            IMongoDatabase _database = _client.GetDatabase(Utilities.MongoServerDB);
            Content content = _database.GetCollection<Content>(collectionName).Find(item => item.Device.DeviceId == deviceId).SingleOrDefault();
            string path = string.Empty;
            if (content != null)
            {
                switch (videoType)
                {
                    case "install":
                        path = content.Path.InstallPath;
                        break;
                    case "repairpath":
                        path = content.Path.InstallPath;
                        break;
                    case "configpath":
                        path = content.Path.InstallPath;
                        break;
                    default:
                        path = content.Path.InstallPath;
                        break;
                }
            }
            return path;
        }

        public List<Job> GetJobByEmployee(int employeeId, string collectionName)
        {
            IMongoClient _client = new MongoClient(Utilities.MongoServerUrl);
            IMongoDatabase _database = _client.GetDatabase(Utilities.MongoServerDB);
            return _database.GetCollection<Job>(collectionName).Find(id => id.Employee.EmployeeId == employeeId).ToList();
        }
    }
}

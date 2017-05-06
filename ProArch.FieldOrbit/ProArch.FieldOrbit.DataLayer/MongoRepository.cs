using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using ProArch.FieldOrbit.DataLayer.Common;
using ProArch.FieldOrbit.Models;
using ProArch.FieldOrbit.Models.Enums;

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
            return _database.GetCollection<WorkRequest>(collectionName).Find(id => id.WorkRequestId == workRequestId).SingleOrDefault();
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
            return _database.GetCollection<ServiceRequest>(collectionName).Find(id => id.ServiceRequestId == serviceRequestId).SingleOrDefault();
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
        public DeviceExpert GetExpert(string deviceId, string collectionName)
        {
            IMongoClient _client = new MongoClient(Utilities.MongoServerUrl);
            IMongoDatabase _database = _client.GetDatabase(Utilities.MongoServerDB);

            var data = _database.GetCollection<DeviceExpert>(collectionName).AsQueryable().ToList();

            //var filter = Builders<DeviceExpert>.Filter.Eq("servicerequestid", serviceRequest.ServiceRequestId);

            //db.job.find({ "workrequest.servicerequest.customer.customerid":1001}).sort({ "jobid":1}).pretty()

            return _database.GetCollection<DeviceExpert>(collectionName).Find(item => item.Devices.Find(d => d.DeviceId == deviceId) != null).SingleOrDefault();
        }

        public string GetVideoPath(string deviceId, string videoType, string collectionName)
        {
            IMongoClient _client = new MongoClient(Utilities.MongoServerUrl);
            IMongoDatabase _database = _client.GetDatabase(Utilities.MongoServerDB);
            Content content = _database.GetCollection<Content>(collectionName).Find(item => item.Device.DeviceId == deviceId).SingleOrDefault();
            string path = string.Empty;
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
            return path;
        }
    }
}

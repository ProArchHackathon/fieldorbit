using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using ProArch.FieldOrbit.DataLayer.Common;
using ProArch.FieldOrbit.Models;

namespace ProArch.FieldOrbit.DataLayer
{
    public class MongoRepository
    {
        /// <summary>
        /// This is only for test purpose we remove once we started coding.
        /// </summary>
        /// <returns></returns>
        public bool IsConnected()
        {
            IMongoClient _client = new MongoClient(Utilities.MongoServerUrl);
            IMongoDatabase _database = _client.GetDatabase(Utilities.MongoServerDB);
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
            var serviceReq = _database.GetCollection<ServiceRequest>(collectionName);
            //return serviceReq;
            return null;
        }

        public ServiceRequest GetServiceRequestBySRNumber(int serviceRequestId, string collectionName)
        {
            IMongoClient _client = new MongoClient(Utilities.MongoServerUrl);
            IMongoDatabase _database = _client.GetDatabase(Utilities.MongoServerDB);
            ServiceRequest wrequest = _database.GetCollection<ServiceRequest>(collectionName).Find(id => id.ServiceRequestId == serviceRequestId).SingleOrDefault();
            return wrequest;
        }
    }
}

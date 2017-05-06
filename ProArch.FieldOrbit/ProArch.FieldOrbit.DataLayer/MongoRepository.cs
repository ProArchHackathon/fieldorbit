using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using ProArch.FieldOrbit.DataLayer.Common;

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
    }
}

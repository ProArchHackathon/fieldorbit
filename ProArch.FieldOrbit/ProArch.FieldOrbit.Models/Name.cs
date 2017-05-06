using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProArch.FieldOrbit.Models
{
    [BsonIgnoreExtraElements]
    public class Name : ModelBase
    {
        [BsonElement("firstname")]
        public string FirstName { get; set; }

        [BsonElement("middlename")]
        public string MiddleName { get; set; }

        [BsonElement("lastname")]
        public string LastName { get; set; }
    }
}

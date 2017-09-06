using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
namespace ProArch.FieldOrbit.Models
{
    [BsonIgnoreExtraElements]
    public class Customer : ModelBase
    {
        [BsonElement("customerid")]
        public int CustomerId { get; set; }

        [BsonElement("deviceid")]
        public string DeviceId { get; set; }

        [BsonElement("AssetId")]
        public string AssetId { get; set; }

        [BsonElement("name")]
        public Name Name { get; set; }

        public List<Address> Address { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }

        [BsonElement("ssn")]
        public string SSN { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("active")]
        public bool Active { get; set; }        
    }
}
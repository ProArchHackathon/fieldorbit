using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace ProArch.FieldOrbit.Models
{
    [BsonIgnoreExtraElements]
    public class Customer : ModelBase
    {
        [BsonElement("customerid")]
        public int CustomerId { get; set; }
        [BsonElement("DeviceId")]
        public int DeviceId { get; set; }
        [BsonElement("AssetId")]
        public int AssetId { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string SSN { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }        
    }
}
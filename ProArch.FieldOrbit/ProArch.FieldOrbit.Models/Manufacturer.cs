using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ProArch.FieldOrbit.Models
{
    public class Manufacturer : ModelBase
    {
        [BsonElement("manufacturerid")]
        public int ManufacturerId { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("manufacturerdate")]
        public DateTime ManufactureDate { get; set; }
        [BsonElement("expirydate")]
        public DateTime ExpiryDate { get; set; }
    }
}

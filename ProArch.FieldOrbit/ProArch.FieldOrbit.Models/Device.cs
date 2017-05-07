using ProArch.FieldOrbit.Models.Enums;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ProArch.FieldOrbit.Models
{
    [BsonIgnoreExtraElements]
    public class Device : ModelBase
    {
        [BsonElement("deviceid")]
        public string DeviceId { get; set; }
        [BsonElement("devicetype")]
        public string DeviceType { get; set; }
        [BsonElement("modelno")]
        public int ModelNumber { get; set; }
        [BsonElement("cost")]
        public decimal Cost { get; set; }
        [BsonElement("createddate")]
        public DateTime CreatedDate { get; set; }
        [BsonElement("yearofpurchase")]
        public int YearOfPurchase { get; set; }
        [BsonElement("manufacturer")]
        public Manufacturer Manufacturer { get; set; }
    }
}

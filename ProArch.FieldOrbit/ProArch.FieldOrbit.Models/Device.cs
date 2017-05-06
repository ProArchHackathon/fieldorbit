﻿using ProArch.FieldOrbit.Models.Enums;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ProArch.FieldOrbit.Models
{
    [BsonIgnoreExtraElements]
    public class Device : ModelBase
    {
        [BsonElement("deviceid")]
        public int DeviceId { get; set; }
        [BsonElement("devicetype")]
        public DeviceType DeviceType { get; set; }
        [BsonElement("serialno")]
        public double ModelNumber { get; set; }
        public decimal Cost { get; set; }
        public int YearOfPurchase { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}

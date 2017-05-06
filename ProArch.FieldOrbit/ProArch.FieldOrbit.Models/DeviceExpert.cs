using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ProArch.FieldOrbit.Models
{
    [BsonIgnoreExtraElements]
    public class DeviceExpert : ModelBase
    {
        [BsonElement("deviceexpertid")]
        public int DeviceExpertId { get; set; }

        [BsonElement("employee")]
        public Employee Employee { get; set; }

        [BsonElement("device")]
        public List<Device> Devices { get; set; }
    }
}

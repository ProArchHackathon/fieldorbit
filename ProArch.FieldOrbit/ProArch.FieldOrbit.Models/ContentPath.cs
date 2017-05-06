using MongoDB.Bson.Serialization.Attributes;

namespace ProArch.FieldOrbit.Models
{
    [BsonIgnoreExtraElements]
    public class ContentPath
    {
        [BsonElement("installpath")]
        public string InstallPath { get; set; }

        [BsonElement("repairpath")]
        public string RepairPath { get; set; }

        [BsonElement("configpath")]
        public string ConfigurationPath { get; set; }
    }
}

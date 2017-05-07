using MongoDB.Bson.Serialization.Attributes;
using ProArch.FieldOrbit.Models.Enums;
using System;

namespace ProArch.FieldOrbit.Models
{
    [BsonIgnoreExtraElements]
    public class Content : ModelBase
    {
        [BsonElement("contentid")]
        public int ContentId { get; set; }

        [BsonElement("device")]
        public Device Device { get; set; }

        [BsonElement("contenttype")]
        public string ContentType { get; set; }

        [BsonElement("contentpath")]
        public ContentPath Path { get; set; }

        [BsonElement("uploadedby")]
        public Employee UploadedBy { get; set; }

        [BsonElement("uploadedon")]
        public DateTime UploadedOn { get; set; }
    }
}

using System;
using MongoDB.Bson.Serialization.Attributes;

namespace ProArch.FieldOrbit.Models
{
    [BsonIgnoreExtraElements]
    public class WorkRequest : ModelBase
    {
        [BsonElement("workorderid")]
        public int WorkRequestId { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("startdate")]
        public DateTime StartDate { get; set; }
        [BsonElement("enddate")]
        public DateTime? EndDate { get; set; }
        [BsonElement("servicerequest")]
        public ServiceRequest ServiceRequest { get; set; }
        [BsonElement("status")]
        public string Status { get; set; }                
    }
}

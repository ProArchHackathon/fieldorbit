using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ProArch.FieldOrbit.Models
{
    [BsonIgnoreExtraElements]
    public class Job : ModelBase
    {
        [BsonElement("jobid")]
        public int JobId { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }

        [BsonElement("priority")]
        public string Priority { get; set; }

        [BsonElement("jobdescription")]
        public string JobDescription { get; set; }

        [BsonElement("starttime")]
        public DateTime? StartTime { get; set; }

        [BsonElement("endtime")]
        public DateTime? EndTime { get; set; }

        [BsonElement("comments")]
        public string Comments { get; set; }

        [BsonElement("observations")]
        public string Observations { get; set; }

        [BsonElement("servicerequest")]
        public ServiceRequest ServiceRequest { get; set; }

        [BsonElement("employee")]
        public Employee Employee { get; set; }

        [BsonElement("customer")]
        public Customer Customer { get; set; }
    }
}

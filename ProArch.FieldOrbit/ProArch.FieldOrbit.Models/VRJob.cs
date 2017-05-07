using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ProArch.FieldOrbit.Models
{
    [BsonIgnoreExtraElements]
    public class VRJob : ModelBase
    {
        [BsonElement("jobid")]
        public int JobId { get; set; }

        [BsonElement("jobdescription")]
        public string JobDescription { get; set; }

        [BsonElement("priority")]
        public string Priority { get; set; }        
    }
}

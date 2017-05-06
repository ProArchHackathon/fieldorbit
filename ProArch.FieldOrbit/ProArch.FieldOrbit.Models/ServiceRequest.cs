﻿using ProArch.FieldOrbit.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace ProArch.FieldOrbit.Models
{
    [BsonIgnoreExtraElements]
    public class ServiceRequest : ModelBase
    {
        [BsonElement("servicerequestid")]
        public int ServiceRequestId { get; set; }
        [BsonElement("createddate")]
        public DateTime CreatedDate { get; set; }
        [BsonElement("startdate")]
        public DateTime StartDate { get; set; }
        [BsonElement("servicetype")]
        public ServiceType ServiceType { get; set; }
        [BsonElement("requesttype")]
        public RequestType RequestType { get; set; }

        [BsonElement("customer")]
        public Customer Customer { get; set; }

        [BsonElement("device")]
        public Device Device { get; set; }

        [BsonElement("location")]
        public string Location { get; set; }
        [BsonElement("closedate")]
        public DateTime? EndDate { get; set; }
        [BsonElement("closedby")]
        public Employee ClosedBy { get; set; }
        [BsonElement("status")]
        public ServiceRequestStatus Status { get; set; }        
    }
}

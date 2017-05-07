using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ProArch.FieldOrbit.Models
{
    [BsonIgnoreExtraElements]
    public class Employee : ModelBase
    {
        [BsonElement("employeeid")]
        public int EmployeeId { get; set; }

        [BsonElement("employeetype")]
        public string EmployeeType { get; set; }

        [BsonElement("name")]
        public Name Name { get; set; }

        [BsonElement("address")]
        public Address Address { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }

        [BsonElement("ssn")]
        public string SSN { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("active")]
        public bool Active { get; set; }  
        
        [BsonElement("voicecalluserid")]
        public string VoiceCallUserId { get; set; }

        [BsonElement("timesheet")]
        public List<Timesheet> Timesheets { get; set; }
    }
}

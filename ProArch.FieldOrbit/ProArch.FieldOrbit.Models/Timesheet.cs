using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ProArch.FieldOrbit.Models
{
    [BsonIgnoreExtraElements]
    public class Timesheet : ModelBase
    {
        [BsonElement("timesheetid")]
        public int TimesheetId { get; set; }

        [BsonElement("Workdate")]
        public DateTime? WorkDate { get; set; }

        [BsonElement("hours")]
        public int Hours { get; set; }

        [BsonElement("comments")]
        public string Comments { get; set; }
    }
}

using MongoDB.Bson.Serialization.Attributes;

namespace ProArch.FieldOrbit.Models
{
    [BsonIgnoreExtraElements]
    public class Address : ModelBase
    {
        [BsonElement("street")]
        public string Street { get; set; }

        [BsonElement("city")]
        public string City { get; set; }

        [BsonElement("state")]
        public string State { get; set; }

        [BsonElement("zip")]
        public string Zip { get; set; }        
    }
}

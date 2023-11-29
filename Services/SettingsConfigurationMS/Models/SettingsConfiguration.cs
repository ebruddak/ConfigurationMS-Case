using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SettingsConfigurationMS.Models
{
    public class SettingsConfiguration
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UUID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public bool IsActive { get; set; }
        public string ApplicationName { get; set; }
    }
}

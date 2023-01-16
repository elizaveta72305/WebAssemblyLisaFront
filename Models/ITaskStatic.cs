using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace WebAssemblyF.Models
{
    [Serializable, BsonIgnoreExtraElements]

    public class ITaskStatic
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string? STaskId { get; set; }

        [JsonProperty("name")]
        [BsonElement("name"), BsonRepresentation(BsonType.String)]
        public string Name { get; set; }

        [JsonProperty("category")]
        [BsonElement("category")]
        public string[] Category { get; set; }

        [JsonProperty("durationLimit")]
        [BsonElement("durationLimit"), BsonRepresentation(BsonType.Int32)]
        public int DurationLimit { get; set; }

        [JsonProperty("points")]
        [BsonElement("points"), BsonRepresentation(BsonType.Int32)]
        public int Points { get; set; }

        [JsonProperty("bonusTask")]
        [BsonElement("bonusTask"), BsonRepresentation(BsonType.String)]
        public string BonusTask { get; set; }

        [JsonProperty("extraTime")]
        [BsonElement("extraTime"), BsonRepresentation(BsonType.Int32)]
        public int ExtraTime { get; set; }

        [JsonProperty("extraPoints")]
        [BsonElement("extraPoints"), BsonRepresentation(BsonType.Int32)]
        public int ExtraPoints { get; set; }

        [JsonProperty("description")]
        [BsonElement("description"), BsonRepresentation(BsonType.String)]
        public string Description { get; set; }

    }
}

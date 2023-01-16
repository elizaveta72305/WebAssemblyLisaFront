using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace WebAssemblyF.Models
{
    [Serializable, BsonIgnoreExtraElements]

    public class ITaskDynamic
    {
        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string? DTaskId { get; set; }

        [JsonProperty("taskStatic")]
        [BsonElement("taskStatic")]
        public ITaskStatic TaskStatic { get; set; }

        [JsonProperty("startTime")]
        [BsonElement("startTime"), BsonRepresentation(BsonType.DateTime)]
        public DateTime StartTime { get; set; }

        [JsonProperty("endTime")]
        [BsonElement("endTime"), BsonRepresentation(BsonType.DateTime)]
        public DateTime? EndTime { get; set; }

        [JsonProperty("collaboratorEmails")]
        [BsonElement("collaboratorEmails")]
        public string[] CollaboratorEmails { get; set; }

        [JsonProperty("solution")]
        [BsonElement("solution"), BsonRepresentation(BsonType.String)]
        public string? Solution { get; set; }

        [JsonProperty("points")]
        [BsonElement("points"), BsonRepresentation(BsonType.Int32)]
        public int? Points { get; set; }
    }

}

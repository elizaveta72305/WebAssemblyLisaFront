//using System;
////using Microsoft.AspNetCore.Mvc;
//namespace WebAssemblyF.Models;

//public class ITaskStatic
//{

//    public string _id { get; set; } = string.Empty;
//    public string name { get; set; } = string.Empty;
//    public List<string> category { get; set; } = new List<string>();
//    public int durationLimit { get; set; }
//    public int points { get; set; }
//    public string bonusTask { get; set; } = string.Empty;
//    public int extraTime { get; set; }
//    public int extraPoints { get; set; }
//    public string description { get; set; } = string.Empty;
//    public int __v { get; set; }

//}

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace WebAssemblyF.Models
{
    [Serializable, BsonIgnoreExtraElements]

    public class ITaskStatic
    {
		[BsonId, BsonRepresentation(BsonType.ObjectId)]
		public string _id { get; set; }

        [BsonId, BsonRepresentation(BsonType.ObjectId)]
        public string? STaskId { get; set; }

        [JsonProperty("name")]
        [BsonElement("name"), BsonRepresentation(BsonType.String)]
        public string name { get; set; }

        [JsonProperty("category")]
        [BsonElement("category")]
        public List<string> category { get; set; } = new List<string>();

        [JsonProperty("durationLimit")]
        [BsonElement("durationLimit"), BsonRepresentation(BsonType.Int32)]
        public int durationLimit { get; set; }

        [JsonProperty("points")]
        [BsonElement("points"), BsonRepresentation(BsonType.Int32)]
        public int points { get; set; }

        [JsonProperty("bonusTask")]
        [BsonElement("bonusTask"), BsonRepresentation(BsonType.String)]
        public string bonusTask { get; set; }

        [JsonProperty("extraTime")]
        [BsonElement("extraTime"), BsonRepresentation(BsonType.Int32)]
        public int extraTime { get; set; }

        [JsonProperty("extraPoints")]
        [BsonElement("extraPoints"), BsonRepresentation(BsonType.Int32)]
        public int extraPoints { get; set; }

        [JsonProperty("description")]
        [BsonElement("description"), BsonRepresentation(BsonType.String)]
        public string description { get; set; }
    }
}
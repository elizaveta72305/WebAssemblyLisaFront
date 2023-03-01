using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace WebAssemblyF.Models
{
	public class CompetitionModel
	{
		[JsonProperty("_id")]
		[BsonId, BsonRepresentation(BsonType.ObjectId)] 

		public string? _id { get; set; }

		[BsonElement("name"), BsonRepresentation(BsonType.String)]
		public string Name { get; set; }

		[BsonElement("status"), BsonRepresentation(BsonType.String)]
		public string? Status { get; set; }

		[BsonElement("numberOfParallel"), BsonRepresentation(BsonType.Int32)]
		public int NumberOfParallel { get; set; }

		[BsonElement("SMcode"), BsonRepresentation(BsonType.String)]
		public string SMcode { get; set; }

		[BsonElement("listOfTasks")]
		public string[]? ListOfTasks { get; set; }

		[BsonElement("competitionAdmin"), BsonRepresentation(BsonType.String)]
		public string CompetitionAdmin { get; set; }

		[BsonElement("teams")]
		public string[]? Teams { get; set; }

		[BsonElement("participants")]
		public List<string>? Participants { get; set; }
	}
}

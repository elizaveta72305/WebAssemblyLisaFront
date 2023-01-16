using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebAssemblyF.Models
{
	public class CompetitionModel
	{
		[BsonId, BsonRepresentation(BsonType.ObjectId)] //Name, Number of parallel tasks, SM code, List of tasks.

		public string? CompetitionId { get; set; }

		[BsonElement("name"), BsonRepresentation(BsonType.String)]
		public string Name { get; set; }

		[BsonElement("status"), BsonRepresentation(BsonType.String)]
		public string Status { get; set; }

		[BsonElement("numberOfParallel"), BsonRepresentation(BsonType.Int32)]
		public int NumberOfParallel { get; set; }

		[BsonElement("SMcode"), BsonRepresentation(BsonType.String)]
		public string SMcode { get; set; }

		[BsonElement("listOfTasks")]
		public string[] ListOfTasks { get; set; }

		[BsonElement("competitionAdmin"), BsonRepresentation(BsonType.String)]
		public string CompetitionAdmin { get; set; }

		[BsonElement("teams")]
		public string[] Teams { get; set; }

		[BsonElement("participants")]
		public string[] Participants { get; set; }
	}
}

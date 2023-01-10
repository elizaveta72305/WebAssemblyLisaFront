using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebAssemblyF.Models
{
	public class Dashboard
	{
		[BsonId, BsonRepresentation(BsonType.ObjectId)]
		public string? StatusId { get; set; }

		[BsonElement("teamName"), BsonRepresentation(BsonType.String)]
		public string TeamName { get; set; }

		public List<CategoryTasks> ListOfTasks { get; set; }
	}
}

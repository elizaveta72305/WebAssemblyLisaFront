using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebAssemblyF.Models
{
	[Serializable, BsonIgnoreExtraElements]
	public class UserModel
	{
		[BsonId, BsonRepresentation(BsonType.ObjectId)]
		public string? UserId { get; set; }

		[BsonElement("email"), BsonRepresentation(BsonType.String)]
		public string email { get; set; }

        [BsonElement("_id"), BsonRepresentation(BsonType.String)]
        public string _id { get; set; }

        [BsonElement("firstName"), BsonRepresentation(BsonType.String)]
		public string firstName { get; set; }

		[BsonElement("lastName"), BsonRepresentation(BsonType.String)]
		public string lastName { get; set; }

		[BsonElement("teamName"), BsonRepresentation(BsonType.String)]
		public string? TeamName { get; set; }

		[BsonElement("role")]
		public string[]? role { get; set; }
	}
}

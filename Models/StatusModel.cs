using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebAssemblyF.Models;

	public class StatusModel
	{
		[BsonId, BsonRepresentation(BsonType.ObjectId)]

		public string? StatusId { get; set; }

		[BsonElement("status"), BsonRepresentation(BsonType.String)]
		public string Status { get; set; }
	}



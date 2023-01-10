using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebAssemblyF.Models;

	public class TaskModel
	{
		[BsonId, BsonRepresentation(BsonType.ObjectId)]
		public string? TaskId { get; set; }

		[BsonElement("category")]
		public string[] TaskCategory { get; set; }

		[BsonElement("name"), BsonRepresentation(BsonType.String)]
		public string Name { get; set; }

		[BsonElement("durationLimit"), BsonRepresentation(BsonType.Int32)]
		public int DurationLimit { get; set; }

		[BsonElement("points"), BsonRepresentation(BsonType.Int32)]
		public int Points { get; set; }

		[BsonElement("bonusTask"), BsonRepresentation(BsonType.String)]
		public string BonusTask { get; set; }

		[BsonElement("extraTime"), BsonRepresentation(BsonType.Int32)]
		public int ExtraTime { get; set; }

		[BsonElement("extraPoints"), BsonRepresentation(BsonType.Int32)]
		public int ExtraPoints { get; set; }

		[BsonElement("description"), BsonRepresentation(BsonType.String)]
		public string Description { get; set; }
	}

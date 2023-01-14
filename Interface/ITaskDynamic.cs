using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAssemblyF.Interface
{
	public class ITaskDynamic
	{
		[BsonElement("taskStatic")]
		ITaskStatic taskStatic { get; set; }

		[BsonElement("startTime"), BsonRepresentation(BsonType.DateTime)]
		DateTime startTime { get; set; }

		[BsonElement("endTime"), BsonRepresentation(BsonType.DateTime)]
		DateTime? endTime { get; set; }

		[BsonElement("collaboratorEmails")]
		string[] CollaboratorEmails { get; set; }

		[BsonElement("solution"), BsonRepresentation(BsonType.String)]
		string? solution { get; set; }

		[BsonElement("points"), BsonRepresentation(BsonType.Int32)]
		int? points { get; set; }
	}

}

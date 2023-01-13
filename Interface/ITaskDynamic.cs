using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAssemblyF.Interface
{
	public class ITaskDynamic
	{
		[BsonElement("taskStatic")]
		public ITaskStatic taskStatic { get; set; }

		[BsonElement("startTime"), BsonRepresentation(BsonType.DateTime)]
		DateTime startTime { get; set; }

		[BsonElement("endTime"), BsonRepresentation(BsonType.DateTime)]
		DateTime? endTime { get; set; }

		[BsonElement("collaborators")]
		string[] collaborators { get; set; }

		[BsonElement("solution"), BsonRepresentation(BsonType.String)]
		string? solution { get; set; }
	}

}

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebAssemblyF.Interface
{
	public class ITaskStatic
	{
		[BsonElement("name"), BsonRepresentation(BsonType.String)]
		string name { get; set; }

		[BsonElement("category")]
		string[] category { get; set; }

		[BsonElement("durationLimit"), BsonRepresentation(BsonType.Int32)]

		int durationLimit { get; set; }

		[BsonElement("points"), BsonRepresentation(BsonType.Int32)]

		int points { get; set; }

		[BsonElement("bonusTask"), BsonRepresentation(BsonType.String)]

		string bonusTask { get; set; }

		[BsonElement("extraTime"), BsonRepresentation(BsonType.DateTime)]

		DateTime extraTime { get; set; }

		[BsonElement("extraPoints"), BsonRepresentation(BsonType.Int32)]
		int extraPoints { get; set; }

		[BsonElement("description"), BsonRepresentation(BsonType.String)]

		string description { get; set; }


		
	}
}

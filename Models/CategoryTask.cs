using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebAssemblyF.Models
{
	
		[Serializable, BsonIgnoreExtraElements]

		public class CategoryTasks
		{
		[BsonElement("solvedTask")]
		public Object SolvedTask { get; set; } = null!;

		[BsonElement("submittedTask")]
		public Object SubmittedTask { get; set; } = null!;

		[BsonElement("openerTask")]
		public Object OpenedTask { get; set; } = null!;
	}
}

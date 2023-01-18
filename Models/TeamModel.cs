using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebAssemblyF.Models
{
    [Serializable, BsonIgnoreExtraElements]

	public class TeamModel
	{
		[BsonId, BsonRepresentation(BsonType.ObjectId)]
		public string? TeamId { get; set; }

		[BsonElement("name")]
		public string Name { get; set; }

		[BsonElement("icon")]
		public string? Icon { get; set; }

		[BsonElement("listOfParticipantsEmail")]
		public List<string> ListOfParticipantsEmail { get; set; }

		[BsonElement("listOfTasksDynamicInProgress")]
		public List<ITaskDynamic> ListOfTasksDynamicInProgress { get; set; }

		[BsonElement("listOfTasksDynamicSumbitted")]
		public List<ITaskDynamic> ListOfTasksDynamicSumbitted { get; set; }

		[BsonElement("listOfTasksDynamicSolved")]
		public List<ITaskDynamic> ListOfTasksDynamicSolved { get; set; }

		[BsonElement("finishedTasksNumber"), BsonRepresentation(BsonType.Int32)]
		public int FinishedTasksNumber { get; set; }

		[BsonElement("openedTasksNumber"), BsonRepresentation(BsonType.Int32)]
		public int OpenedTasksNumber { get; set; }

		[BsonElement("earnedPoints"), BsonRepresentation(BsonType.Int32)]
		public int EarnedPoints { get; set; }

		[BsonElement("potentionalPoints"), BsonRepresentation(BsonType.Int32)]
		public int PotentionalPoints { get; set; }
	}
}

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using static System.Runtime.InteropServices.JavaScript.JSType;
using WebAssemblyF.Interface;

namespace WebAssemblyF.Models
{
	public class TeamModel
	{
		[BsonId, BsonRepresentation(BsonType.ObjectId)]
		public string? TeamId { get; set; }

		[BsonElement("name")]
		public string Name { get; set; }

		[BsonElement("icon"), BsonRepresentation(BsonType.String)]
		public string? Icon { get; set; }

		[BsonElement("listOfParticipants")]
		public string[] ListOfParticipants { get; set; }

		[BsonElement("listOfTasksDynamicInProgress")]
		public ITaskDynamic[] ListOfTasksDynamicInProgress { get; set; }

		//[BsonElement("listOfTasksDynamicSumbitted")]
		//public ITaskDynamic[] ListOfTasksDynamicSumbitted { get; set; }

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
//name: string;
//icon: string;
//listOfParticipants: string[];
//listOfTasksDynamicInProgress: ITaskDynamic[];
//listOfTasksDynamicSumbitted: ITaskDynamic[];
//finishedTasksNumber: number;
//openedTasksNumber: number;
//earnedPoints: number;
//potentionalPoints: number;

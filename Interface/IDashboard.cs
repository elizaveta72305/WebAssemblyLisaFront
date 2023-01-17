using WebAssemblyF.Models;

namespace WebAssemblyF.Interface
{
	public class IDashboard
	{
		//public List<TaskModel> myStaticTask { get; set; } = new List<TaskModel>();
		public List<TeamModel> myListOfAllTeams { get; set; } = new List<TeamModel>();
		//public List<TaskModel> Users { get; set; } = new List<TaskModel>();
		public string Team { get; set; }

	}
}

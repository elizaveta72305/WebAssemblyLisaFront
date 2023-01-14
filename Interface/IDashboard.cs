using System.Threading.Tasks;
using WebAssemblyF.Models;
using WebAssemblyF.Services;

namespace WebAssemblyF.Interface
{
		public interface IDashboard
		{
			List<TaskModel> myStaticTask { get; set; }
			List<TeamModel> myListOfAllTeams { get; set; }
			string Team { get; set; }
			Task Initialise();
			Task GetAllTaskStatic();
			Task GetTeamByEmail();


		}
}

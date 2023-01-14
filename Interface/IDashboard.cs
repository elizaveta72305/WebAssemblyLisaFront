using System.Threading.Tasks;
using WebAssemblyF.Models;
using WebAssemblyF.Services;

namespace WebAssemblyF.Interface
{
		public interface IDashboard
		{
			List<TaskModel> MyTask { get; set; }
			List<TeamModel> MyTeam { get; set; }
			Task GetAllTaskStatic();
		}
}

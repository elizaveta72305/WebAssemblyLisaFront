using Microsoft.AspNetCore.Components;
using Microsoft.VisualBasic;
using System.Net.Http.Json;
using WebAssemblyF.Interface;
using WebAssemblyF.Models;
using static System.Net.WebRequestMethods;

namespace WebAssemblyF.Services
{
	public class DashboardService: IDashboard
	{
		private readonly HttpClient _http;
		private readonly NavigationManager _navigationManager;

		public DashboardService(HttpClient http, NavigationManager navigationManager)
		{
			_http = http;
			_navigationManager = navigationManager;
		}

		public List<TaskModel> MyTask { get; set; } = new List<TaskModel>();
		public List<TeamModel> MyTeam { get; set; } = new List<TeamModel>();

		public async Task GetAllTaskStatic()
		{
			var result = await _http.GetFromJsonAsync<List<TaskModel>>("/api/Task");
			if (result != null)
				MyTask = result;
			else
			{
				Console.WriteLine("Error of getting all taskes");
			}
		}
		public async Task GetAllTeams()
		{
			var result = await _http.GetFromJsonAsync<List<TeamModel>>("http://localhost:2050/team/readAll");
			if (result != null)
				MyTeam = result;
			else
			{
				Console.WriteLine("Error of getting all taskes");
			}

		}


	}
}

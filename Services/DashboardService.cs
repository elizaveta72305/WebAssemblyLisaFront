using Microsoft.AspNetCore.Components;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using WebAssemblyF.Services;
using WebAssemblyF.Interface;
using WebAssemblyF.Models;
using WebAssemblyF.Pages;
using WebAssemblyF.Pages.Authentication;
using static System.Net.WebRequestMethods;

namespace WebAssemblyF.Services
{
	public class DashboardService: IDashboard 
	{
		private readonly HttpClient _http;
		private readonly IHttpClientFactory _httpF;
		private readonly NavigationManager _navigationManager;
		private readonly Pages.Index _tokenClass;
		private string userEmail;

		public DashboardService(HttpClient http, NavigationManager navigationManager, Pages.Index tokenClass)
		{
			_http = http;
			_navigationManager = navigationManager;
			_tokenClass = tokenClass;
		}

		//public List<TaskModel> myStaticTask { get; set; } = new List<TaskModel>();
		public List<TeamModel> myListOfAllTeams { get; set; } = new List<TeamModel>();
		//public List<TaskModel> Users { get; set; } = new List<TaskModel>();
		public string Team { get; set; }
		public async Task Initialise()
		{ 
			//userEmail = await _tokenClass.TokenInitializedAsync();
		}

			public async Task GetAllTaskStatic()
			{
			//var result = await _http.GetFromJsonAsync<List<TaskModel>>("/api/Task");
			//	if (result != null)
   //             myStaticTask = result; //ПЕРЕИМЕНОВАТЬ В СТАТИЧЕСКИЕ ТАСКИ.
			//		else
			//	{
			//	Console.WriteLine("Error of getting all taskes");
			//	}
			}
		public async Task GetAllTeams()
		{
			var result = await _http.GetFromJsonAsync<List<TeamModel>>("http://localhost:2050/team/readAll");
			if (result != null)
				myListOfAllTeams = result;
			else
			{
				Console.WriteLine("Error of getting all taskes");
			}
		}

		public async Task GetTeamByEmail()
		{
			var result = await _http.GetFromJsonAsync<List<UserModel>>("/api/User");

			foreach(var oneUser in result)
			{
				if(oneUser.Email == userEmail)
				{
					Team = oneUser.TeamName;
				}
			}
		}
		public async Task sendTask(string taskName, string inputValue)
		{
			var client = _httpF.CreateClient("BlazorWasmApp.AnonymousAPI");
			var parameters = new Dictionary<string, string> { { "taskName", taskName }, { "solution", inputValue } };
			var encodedContent = new FormUrlEncodedContent(parameters);
			var req = await client.PostAsJsonAsync("http://localhost:2050/teamManager/submitTask/", encodedContent);
		}
	}
}

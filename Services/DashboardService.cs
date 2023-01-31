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
		private readonly NavigationManager _navigationManager;
		private readonly Pages.Index _tokenClass;
		private string userEmail;

		public DashboardService(HttpClient http, NavigationManager navigationManager, Pages.Index tokenClass)
		{
			_http = http;
			_navigationManager = navigationManager;
			_tokenClass = tokenClass;
		}

		public List<TaskModel> myStaticTask { get; set; } = new List<TaskModel>();
		public List<TeamModel> myListOfAllTeams { get; set; } = new List<TeamModel>();
		public List<TaskModel> Users { get; set; } = new List<TaskModel>();
		public string Team { get; set; }
		public List<CompetitionModel> AllCompetitions { get; set; } = new List<CompetitionModel>();
		public async Task Initialise()
		{ 
			//userEmail = await _tokenClass.TokenInitializedAsync();
		}

			public async Task GetAllTaskStatic()
			{
			var result = await _http.GetFromJsonAsync<List<TaskModel>>("/api/Task");
				if (result != null)
                myStaticTask = result; 
					else
				{
				Console.WriteLine("Error of getting all taskes");
				}
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
				if(oneUser.email == userEmail)
				{
					Team = oneUser.teamName;
				}
			}
		}
		public async Task GetAllCompetition()
		{
			AllCompetitions = await _http.GetFromJsonAsync<List<CompetitionModel>>("api/Competition");
		}

		public async Task<CompetitionModel> GetCompetitionById(string id)
		{
			
			var competitionbyId = await _http.GetFromJsonAsync<CompetitionModel>($"api/Competition/{id}");

			if (competitionbyId != null)
				return competitionbyId;
			throw new Exception("Competition not found!");
		}

		//public async Task CreateTaskStatic(ITaskStatic taskStatic)
		//{
		//	var result = await _http.PostAsJsonAsync($"/taskStatic/create", taskStatic);
		//	_navigationManager.NavigateTo("taskcatalog");
		//}

		public async Task CreateCompetition(CompetitionModel competition)
		{
			var result = await _http.PostAsJsonAsync($"/api/Competition", competition);
			_navigationManager.NavigateTo("currentCompetition");
		}

		public async Task UpdateCompetition(CompetitionModel competition)
		{
			var result = await _http.PutAsJsonAsync<CompetitionModel>($"/api/Competition", competition);
			_navigationManager.NavigateTo("currentCompetition");
		}

		public async Task DeleteCompetition(string id)
		{
			var result = await _http.DeleteAsync($"/api/Competition/{id}");
			_navigationManager.NavigateTo("currentCompetition");
		}
	}
}

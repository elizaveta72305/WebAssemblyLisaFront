using System;
using WebAssemblyF.Pages;
using WebAssemblyF.Models;
using static System.Net.WebRequestMethods;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Net.Http.Headers;
//using System.Text.Json;
//using System.Text.Json.Serialization;

using Newtonsoft;
using WebAssemblyF.Services.TaskStaticService;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace WebAssemblyF.Services.TaskStaticService
{ 

	public class TaskStaticService:ITaskStaticService
	{
        public List<ITaskStatic> tasksStatic { get ; set ; }
        public List<string> categories { get; set; }
        private string localhost = "http://localhost:2050";
        private readonly IHttpClientFactory _httpF;
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        private readonly IAccessTokenProvider _TokenProvider;
        private string token = "";

        public TaskStaticService(HttpClient http, IHttpClientFactory httpF, NavigationManager navigationManager, IAccessTokenProvider TokenProvider)
        {
            _httpF = httpF;
            _http = http;
            _navigationManager = navigationManager;
            _TokenProvider = TokenProvider;
            categories = new List<string>();
            categories.Add("Frontend");
            categories.Add("Backend");
            categories.Add("Angular");
            categories.Add("React");
            categories.Add("TypeScript");
            categories.Add("JavaScript");
            categories.Add(".Net");
            categories.Add("C#");
        }

        public async Task GetTasksStatic()
        {
            var accessTokenResult = await _TokenProvider.RequestAccessToken();
            if (accessTokenResult.TryGetToken(out var _token))
            {
                token = _token.Value;
            }
            //Console.WriteLine(token);
            var client = _httpF.CreateClient("BlazorWasmApp.AnonymousAPI");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var result = await client.GetFromJsonAsync<List<ITaskStatic>>($"{localhost}/taskStatic/readAll");
            if (result != null)
                tasksStatic = result;
        }

        public async Task<ITaskStatic> GetSingleTaskStatic(string id)
        {
            var client = _httpF.CreateClient("BlazorWasmApp.AnonymousAPI");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var tsk = await client.GetFromJsonAsync<List<ITaskStatic>>($"{localhost}/taskStatic/readByField?field=_id&value={id}");
            if (tsk != null)
                return tsk[0];
            throw new Exception("Task Static not found!");
        }

        public async Task CreateTaskStatic(ITaskStatic taskStatic)
        {
            var client = _httpF.CreateClient("BlazorWasmApp.AnonymousAPI");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var result = await client.PostAsJsonAsync($"{localhost}/taskStatic/create", taskStatic);
            _navigationManager.NavigateTo("taskcatalog");
            //await SetHeroes(result);
        }

        public async Task UpdateTaskStatic(ITaskStatic taskStatic)
        {
            var client = _httpF.CreateClient("BlazorWasmApp.AnonymousAPI");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var result = await client.PutAsJsonAsync<ITaskStatic>($"{localhost}/taskStatic/updateByField?field=_id&value={taskStatic._id}", taskStatic);
            _navigationManager.NavigateTo("taskcatalog");
            //await SetHeroes(result);
        }

        public async Task DeleteTaskStatic(string id)
        {
            var client = _httpF.CreateClient("BlazorWasmApp.AnonymousAPI");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var result = await client.DeleteAsync($"{localhost}/taskStatic/deleteByField?field=_id&value={id}");
            _navigationManager.NavigateTo("taskcatalog");
        }
    }
}
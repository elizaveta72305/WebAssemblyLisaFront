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

namespace WebAssemblyF.Services.TaskStaticService
{ 
//    public class Field
//{
//        [JsonProperty]
//        string fieldTitle { get; set; }
//        [JsonProperty]
//        object filedValue { get; set; }
//        public Field(string fieldTitle, object filedValue)
//        {
//            this.fieldTitle = fieldTitle;
//            this.filedValue = filedValue;
//        }
//        public override string ToString()
//        {
//            return $"{this.fieldTitle}:{this.filedValue}";
//        }
//    }


	public class TaskStaticService:ITaskStaticService
	{
        public List<ITaskStatic> tasksStatic { get ; set ; }
        public List<string> categories { get; set; }
        private string localhost = "http://localhost:2050";
        private readonly IHttpClientFactory _httpF;
        private readonly NavigationManager _navigationManager;
        //private string token = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IlFvLWZ5Yl9WajBNemh4REFVTmVLVSJ9.eyJtYWlsIjoiZWVndWFyQGdtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6WyJDb21wZXRpdGlvbiBhZG1pbmlzdHJhdG9yIiwiUGFydGljaXBhbnQiLCJTeXN0ZW0gYWRtaW5pc3RyYXRvciJdLCJpc3MiOiJodHRwczovL2Rldi15NGJnN3RhZGtkeDBzN3g2LnVzLmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHw2M2IzMGQ0OGY3MWY0YzU4ZWRmOWVlNzciLCJhdWQiOlsiaHR0cHM6Ly9sb2NhbGhvc3Q6NzE5MiIsImh0dHBzOi8vZGV2LXk0Ymc3dGFka2R4MHM3eDYudXMuYXV0aDAuY29tL3VzZXJpbmZvIl0sImlhdCI6MTY3Mzg2MTc0NSwiZXhwIjoxNjczOTQ4MTQ1LCJhenAiOiJyajlYZnlmZHlKcEhOeUVXa3NBcmlscGVxZ3hIMXRpNCIsInNjb3BlIjoib3BlbmlkIHByb2ZpbGUgZW1haWwiLCJwZXJtaXNzaW9ucyI6W119.Bi3J37eZOB0BbXuw3BDdAulC7MFjDP0l9of_jt__grw87r4qMa1OtV4wywMMGJK4XFPVTwkzz2ApEtwIXeiarDUxSePgHD3ckfTCx1jAgOdJ38ULDJqDwijBlm6bvMdTEuUxMSfgK5WZNNVf9ocjojo7UTg6Zphtz74TMTOQG2wYH8Ucg_gzCnpmgejMECj3GhxZBaXqi-SFG0ZNTuFn-6Pvj7jcgxtytIKNIelzEWEILygmg70_PS929jINC85dMyqCO9orxUejZg0oDoD1CkIFamsI9ujg6TzlazZ2zVHnC4pxPPvYEW4VQ9ExzJXobWZRnZpcW5gblKCXhBkwmwQ";
        //private string token = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IlFvLWZ5Yl9WajBNemh4REFVTmVLVSJ9.eyJtYWlsIjoiZWVndWFyQGdtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6WyJDb21wZXRpdGlvbiBhZG1pbmlzdHJhdG9yIiwiUGFydGljaXBhbnQiLCJTeXN0ZW0gYWRtaW5pc3RyYXRvciJdLCJpc3MiOiJodHRwczovL2Rldi15NGJnN3RhZGtkeDBzN3g2LnVzLmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHw2M2IzMGQ0OGY3MWY0YzU4ZWRmOWVlNzciLCJhdWQiOlsiaHR0cHM6Ly9sb2NhbGhvc3Q6NzE5MiIsImh0dHBzOi8vZGV2LXk0Ymc3dGFka2R4MHM3eDYudXMuYXV0aDAuY29tL3VzZXJpbmZvIl0sImlhdCI6MTY3Mzg2MTc0NSwiZXhwIjoxNjczOTQ4MTQ1LCJhenAiOiJyajlYZnlmZHlKcEhOeUVXa3NBcmlscGVxZ3hIMXRpNCIsInNjb3BlIjoib3BlbmlkIHByb2ZpbGUgZW1haWwiLCJwZXJtaXNzaW9ucyI6W119.Bi3J37eZOB0BbXuw3BDdAulC7MFjDP0l9of_jt__grw87r4qMa1OtV4wywMMGJK4XFPVTwkzz2ApEtwIXeiarDUxSePgHD3ckfTCx1jAgOdJ38ULDJqDwijBlm6bvMdTEuUxMSfgK5WZNNVf9ocjojo7UTg6Zphtz74TMTOQG2wYH8Ucg_gzCnpmgejMECj3GhxZBaXqi-SFG0ZNTuFn-6Pvj7jcgxtytIKNIelzEWEILygmg70_PS929jINC85dMyqCO9orxUejZg0oDoD1CkIFamsI9ujg6TzlazZ2zVHnC4pxPPvYEW4VQ9ExzJXobWZRnZpcW5gblKCXhBkwmw";
        private string token = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IlFvLWZ5Yl9WajBNemh4REFVTmVLVSJ9.eyJtYWlsIjoiZWVndWFyQGdtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6WyJDb21wZXRpdGlvbiBhZG1pbmlzdHJhdG9yIiwiUGFydGljaXBhbnQiLCJTeXN0ZW0gYWRtaW5pc3RyYXRvciJdLCJpc3MiOiJodHRwczovL2Rldi15NGJnN3RhZGtkeDBzN3g2LnVzLmF1dGgwLmNvbS8iLCJzdWIiOiJhdXRoMHw2M2IzMGQ0OGY3MWY0YzU4ZWRmOWVlNzciLCJhdWQiOlsiaHR0cHM6Ly9sb2NhbGhvc3Q6NzE5MiIsImh0dHBzOi8vZGV2LXk0Ymc3dGFka2R4MHM3eDYudXMuYXV0aDAuY29tL3VzZXJpbmZvIl0sImlhdCI6MTY3Mzk1MjYzMCwiZXhwIjoxNjc0MDM5MDMwLCJhenAiOiJyajlYZnlmZHlKcEhOeUVXa3NBcmlscGVxZ3hIMXRpNCIsInNjb3BlIjoib3BlbmlkIHByb2ZpbGUgZW1haWwiLCJwZXJtaXNzaW9ucyI6W119.K-8AhoLg27wEay8OL7cY1f-x-S6IYJHX1idHILQBaQrXhyhV1lFcWtogxHgTatMffEqz11NERPpxdPkUbqFA3KbLG61y7fLBm0oPWa6be3lJqeBUTGvBjXH422jln7D1l3Ua-xdiOEPc9mnxQDRpTKNIdZTXFaKn4sQ__vgtsqAmW7F_vbok_Xx-JoNtv9R8C32KzTMTwAgMR2cE0dRBORY9iMSTkwGi1UqlMf-chLLWrusVf2_v-3eCeD4cFSj5CkXPBOAh6NL3KO4oiBBXy7q8HwQx90ephip4DQqGe6lv6CAYr8W9IMOycfECVliTABVtkv6juBA0IgJjaxAvww";
        public TaskStaticService(IHttpClientFactory httpF, NavigationManager navigationManager)
        {
            _httpF = httpF;
            _navigationManager = navigationManager;
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
        //private JsonSerializerOptions options = new JsonSerializerOptions()
        //{
        //    ReferenceHandler = ReferenceHandler.Preserve,
        //    PropertyNameCaseInsensitive = false,
        //    IncludeFields = true
        //};

        public async Task GetTasksStatic()
        {
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
            //List<Field> fieldsToUpdate = new List<Field>();

            //    foreach (var prop in taskStatic.GetType().GetProperties())
            //    {
            //    var field = new Field(prop.Name, prop.GetValue(taskStatic));
            //    fieldsToUpdate.Add(field);

            //    }
            
            var client = _httpF.CreateClient("BlazorWasmApp.AnonymousAPI");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //var str = JsonConvert.SerializeObject(fieldsToUpdate);
            //var content = new StringContent(str, Encoding.UTF8, "application/json");
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

        //public async Task SetTaskStatic(HttpResponseMessage result)
        //{
        //    var responce = await result.Content.ReadFromJsonAsync<List<ITaskStatic>>();
        //    tasksStatic = responce;
        //    _navigationManager.NavigateTo("superheroes");
        //}

    }
}
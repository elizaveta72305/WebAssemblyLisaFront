using System;
using WebAssemblyF.Pages;
using WebAssemblyF.Models;
using static System.Net.WebRequestMethods;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Net.Http.Headers;
using Newtonsoft;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace WebAssemblyF.Services.UserService
{

public class UserService : IUserService
    {
        public List<UserModel> users { get ; set ; }
        private string localhost = "http://localhost:2050";
        private readonly IHttpClientFactory _httpF;
        private readonly NavigationManager _navigationManager;
        public List<string> Roles { get; set; } = new List<string>();
        private string token = "";
        private readonly IAccessTokenProvider _TokenProvider;

        public UserService(IHttpClientFactory httpF, NavigationManager navigationManager, IAccessTokenProvider TokenProvider)
        {
            _httpF = httpF;
            _navigationManager = navigationManager;
            _TokenProvider = TokenProvider;
            Roles.Add("System administrator");
            Roles.Add("Competition administrator");
            Roles.Add("Participant");
        }

        public async Task GetUsers()
        {
            var accessTokenResult = await _TokenProvider.RequestAccessToken();
            if (accessTokenResult.TryGetToken(out var _token))
            {
                token = _token.Value;
            }
            var client = _httpF.CreateClient("BlazorWasmApp.AnonymousAPI");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var result = await client.GetFromJsonAsync<List<UserModel>>($"{localhost}/user/readAll");
            if (result != null)
            users = result;
        }

        public async Task<UserModel> GetSingleUser(string id)
        {
            var client = _httpF.CreateClient("BlazorWasmApp.AnonymousAPI");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var user = await client.GetFromJsonAsync<List<UserModel>>($"{localhost}/user/readByField?field=_id&value={id}");
            if (user != null)
                return user[0];
            throw new Exception("User not found!");
        }

        public async Task CreateUser(UserModel user)
        {
            var client = _httpF.CreateClient("BlazorWasmApp.AnonymousAPI");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var result = await client.PostAsJsonAsync($"{localhost}/user/create", user);
            _navigationManager.NavigateTo("users");
            //await SetHeroes(result);
        }

        public async Task UpdateUser(UserModel user)
        {
            
            var client = _httpF.CreateClient("BlazorWasmApp.AnonymousAPI");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //var str = JsonConvert.SerializeObject(fieldsToUpdate);
            //var content = new StringContent(str, Encoding.UTF8, "application/json");
            var result = await client.PutAsJsonAsync<UserModel>($"{localhost}/user/updateByField?field=_id&value={user._id}", user);
            _navigationManager.NavigateTo("users");
            //await SetHeroes(result);
        }

        public async Task DeleteUser(string id)
        {
            var client = _httpF.CreateClient("BlazorWasmApp.AnonymousAPI");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var result = await client.DeleteAsync($"{localhost}/user/deleteByField?field=_id&value={id}");
            _navigationManager.NavigateTo("users");
        }

    }
}

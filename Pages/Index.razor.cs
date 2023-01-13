using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Authorization;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using MongoDB.Bson.IO;
using System.Text.RegularExpressions;

//using Newtonsoft.Json;

namespace WebAssemblyF.Pages;

	[Authorize]

	public partial class Index : ComponentBase
	{
		[Inject]
		IAccessTokenProvider TokenProvider { get; set; }

		public string AccessToken { get; set; }

	protected override async Task OnInitializedAsync()
	{
		var accessTokenResult = await TokenProvider.RequestAccessToken();
		var AccessToken = string.Empty;

		if (accessTokenResult.TryGetToken(out var token))
		{
			AccessToken = token.Value;
			var handler = new JwtSecurityTokenHandler();
			var jwtSecurityToken = handler.ReadJwtToken(AccessToken);
			var mail = jwtSecurityToken.Claims.First(c => c.Type == "mail").Value;

			//var claim = token.Claims.First(c => c.Type == "email").Value;
			//return claim;

		}
		
	}
}

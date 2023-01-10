using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using static System.Net.WebRequestMethods;
using System.Net.Http;
using System.Net;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;

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
		}
	}
	}

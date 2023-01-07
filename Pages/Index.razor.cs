using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using static System.Net.WebRequestMethods;

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
		AccessToken = string.Empty;

		if (accessTokenResult.TryGetToken(out var token))
		{
			AccessToken = token.Value;
		}

		//Http.DefaultRequestHeader.Authitrization = new AuthenticationHeaderValue("Bearer", AccessToken);
		//HttpResponceMessage responce = await Http.GetAsync("api/Status");
	}
	}

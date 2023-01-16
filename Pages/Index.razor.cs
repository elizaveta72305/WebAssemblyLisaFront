using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.IdentityModel.Tokens.Jwt;
namespace WebAssemblyF.Pages;

[Authorize]

//public partial class Index : ComponentBase 
//{
//	[Inject]
//	IAccessTokenProvider TokenProvider { get; set; }

//	public string AccessToken { get; set; }

//protected override async Task OnInitializedAsync()
//{
//	var accessTokenResult = await TokenProvider.RequestAccessToken();
//	var AccessToken = string.Empty;

//	if (accessTokenResult.TryGetToken(out var token))
//	{
//		AccessToken = token.Value;
//		var handler = new JwtSecurityTokenHandler();
//		var jwtSecurityToken = handler.ReadJwtToken(AccessToken);
//		var mail = jwtSecurityToken.Claims.First(c => c.Type == "mail").Value;
//	}
//}
public partial class Index : ComponentBase
{
	[Inject]
	IAccessTokenProvider TokenProvider { get; set; }
	public string AccessToken { get; set; }

	//string Email;
	//public async Task<string> TokenInitializedAsync()
	//{
	//	var accessTokenResult = await TokenProvider.RequestAccessToken();
	//	var AccessToken = string.Empty;

	//	if (accessTokenResult.TryGetToken(out var token))
	//	{
	//		AccessToken = token.Value;
	//		var handler = new JwtSecurityTokenHandler();
	//		var jwtSecurityToken = handler.ReadJwtToken(AccessToken);
	//		Email = jwtSecurityToken.Claims.First(c => c.Type == "mail").Value;
	//		return Email;
	//	}
	//	return "";
	//}
}

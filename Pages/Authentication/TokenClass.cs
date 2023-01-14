using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.IdentityModel.Tokens.Jwt;
namespace WebAssemblyF.Pages.Authentication;

//public partial class TokenClass: ComponentBase
//{
//	[Inject]
//	IAccessTokenProvider TokenProvider { get; set; }
//	public string AccessToken { get; set; }

//	string Email;
//	public async Task<string> TokenInitializedAsync()
//	{
//		var accessTokenResult = await TokenProvider.RequestAccessToken();
//		var AccessToken = string.Empty;

//		if (accessTokenResult.TryGetToken(out var token))
//		{
//			AccessToken = token.Value;
//			var handler = new JwtSecurityTokenHandler();
//			var jwtSecurityToken = handler.ReadJwtToken(AccessToken);
//			Email = jwtSecurityToken.Claims.First(c => c.Type == "mail").Value;
//			return Email;
//		}
//		return "";
//	}
//}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.IdentityModel.Tokens.Jwt;
namespace WebAssemblyF.Pages;

[Authorize]

public partial class Index : ComponentBase
{
	[Inject]
	IAccessTokenProvider TokenProvider { get; set; }
	public string AccessToken { get; set; }
}

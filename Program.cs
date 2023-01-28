global using Microsoft.AspNetCore.Components.Authorization;
global using WebAssemblyF.Services.TaskStaticService;
global using WebAssemblyF.Services.UserService;
global using WebAssemblyF.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using WebAssemblyF;
using WebAssemblyF.Interface;
using WebAssemblyF.Pages;
using WebAssemblyF.Services;

using BlazorBootstrap;
using Blazored.Modal;
using WebAssemblyF.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("ServerAPI",
	  client => client.BaseAddress = new Uri("http://localhost:5093"))
	.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

//builder.Services.AddScoped(sp => new HttpClient { }).AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
builder.Services.AddScoped<IDashboard, DashboardService>();
builder.Services.AddScoped<ITaskStaticService, TaskStaticService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddTransient<WebAssemblyF.Pages.Index>();
builder.Services.AddTransient<DashboardService>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
  .CreateClient("ServerAPI"));

builder.Services.AddAuthorizationCore(options =>
{
	options.AddPolicy(Policies.IsAdmin, Policies.IsAdminPolicy());
	options.AddPolicy(Policies.IsCompetitionAdmin, Policies.IsCompetitionAdminPolicy());
	options.AddPolicy(Policies.IsParticipant, Policies.IsParticipantPolicy());
});

builder.Services.AddOidcAuthentication(options =>
{
	builder.Configuration.Bind("Auth0", options.ProviderOptions);
	options.ProviderOptions.ResponseType = "code";
	options.ProviderOptions.AdditionalProviderParameters.Add("audience", builder.Configuration["Auth0:Audience"]);
}).AddAccountClaimsPrincipalFactory<ArrayClaimsPrincipalFactory<RemoteUserAccount>>();


builder.Services.AddBlazorBootstrap();
builder.Services.AddBlazoredModal();

await builder.Build().RunAsync();


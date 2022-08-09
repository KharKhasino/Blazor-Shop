using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OnlineShop.Client;
using OnlineShop.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("OnlineShop.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("OnlineShop.ServerAPI"));
builder.Services.AddScoped<IProductServ, ProductServ>();
builder.Services.AddScoped<IShoppingServ, ShoppingCartServ>();
builder.Services.AddApiAuthorization();

//builder.Services.AddOidcAuthentication(options =>
//{
//    builder.Configuration.Bind("IdentityServer", options.ProviderOptions);
//});

await builder.Build().RunAsync();

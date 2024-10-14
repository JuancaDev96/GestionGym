using Blazored.Toast;
using GestionGym.Ui;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Scrutor;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("Servicios:UrlBackend")!) });
builder.Services.AddBlazoredToast();
builder.Services.AddBlazorBootstrap();
builder.Services.Scan(selector => selector
    .FromAssemblies(Assembly.GetExecutingAssembly())
    .AddClasses(false)
    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
    .AsMatchingInterface()
    .WithScopedLifetime());

await builder.Build().RunAsync();

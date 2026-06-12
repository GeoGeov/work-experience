using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WorkExperience.Client;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.FluentValidation;
using Blazorise.Icons.FontAwesome;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<WorkExperience.Client.Core.Services.HarryPotterService>();

builder.Services.AddBlazorise(options =>
            {
                options.Immediate = true;
                options.ProductToken = "9AC7-58E6-6467-4B22-BF9B-F6CC-F57E";
            })
            .AddBootstrap5Providers()
            .AddFontAwesomeIcons()
            .AddBlazoriseFluentValidation();

await builder.Build().RunAsync();

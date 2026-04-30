using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BankBlazor.Client;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        var apiBaseUrl = builder.Configuration["ApiBaseUrl"];

        builder.Services.AddScoped(sp => new HttpClient
        {
            BaseAddress = new Uri("https://bankblazor-api-a3hmhna9axe2crgv.swedencentral-01.azurewebsites.net/")
        });


        await builder.Build().RunAsync();
    }
}

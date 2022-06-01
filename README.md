# ProblemDetails

## Usage

### Blazor

#### Program.cs

```csharp
...
using Jimmys20.ProblemDetails;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<ProblemDetailsHandler>();

builder.Services
    .AddHttpClient("ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<ProblemDetailsHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ServerAPI"));

await builder.Build().RunAsync();
```

#### _Imports.razor

```razor
...
@using Jimmys20.ProblemDetails
```

#### FetchData.razor

```razor
...

@code {
    private WeatherForecast[]? forecasts;
    
    protected override async Task OnInitializedAsync()
    {
        try
        {
            forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
        }
        catch (ProblemDetailsException ex)
        {
            var problem = ex.Problem;
        }
    }
}
```

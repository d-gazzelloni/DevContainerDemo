using Demo.Infrastructure.EntityFramework.Extensions;
using Demo.Infrastructure.EntityFramework.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(o => { o.SwaggerEndpoint("/openapi/v1.json", "Demo API"); });
}

app.UseHttpsRedirection();

var summaries = new[]
                {
                        "Freezing",
                        "Bracing",
                        "Chilly",
                        "Cool",
                        "Mild",
                        "Warm",
                        "Balmy",
                        "Hot",
                        "Sweltering",
                        "Scorching"
                };

app.MapGet("/weatherforecast",
           () =>
           {
               var env = Environment.GetEnvironmentVariable("CUSTOM_VARIABLE");
               if (env is null)
                   return Results.Unauthorized();

               var forecast = Enumerable.Range(1, 5)
                                        .Select(index => new WeatherForecast(DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                                                                             Random.Shared.Next(-20, 55),
                                                                             summaries[Random.Shared.Next(summaries.Length)]))
                                        .ToArray();
               return Results.Ok(forecast);
           })
   .WithName("GetWeatherForecast");


app.MapGet("/users",
           async ( IApplicationRepository repository) =>
           {
               var users = await repository.GetUsersAsync();
               return Results.Ok(users);
           });

app.MapGet("/Tasks",
           () => Results.Ok("Hello World!"));


app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
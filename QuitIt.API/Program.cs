using QuitIt.API.Controllers;
using QuitIt.API.Models;
using QuitIt.API.Services;

// const string GetLogEndpointName = "GetLog";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddAuthorization();
// builder.Services.AddHttpsRedirection();
var app = builder.Build();

// List<Log> logs = [
//     new("1adf214e-5dfe-4ec5-992c-505176c18027", 1772912381809, 1),
//     new("9a6ff1dd-2998-44dc-9ba4-91045892e21b", 1772912381809, 10),
//     new("749558c2-2e07-4fa4-b0d0-796388566672", 1772912381809, 2),
// ];

// app.MapGet("/logs", () => logs);

// app.MapGet("/logs/{id}", (string id) =>
// {
//     return logs.Find(log => log.Id == id);
// }).WithName(GetLogEndpointName);

// app.MapPost("/logs", (CreateLog newLog) =>
// {
//     Log log = new(
//         Guid.NewGuid().ToString(),
//         DateTimeOffset.Now.ToUnixTimeMilliseconds(),
//         newLog.NumOfCigs
//     );

//     logs.Add(log);
//     return Results.CreatedAtRoute(GetLogEndpointName, new { id = log.Id }, log);
// });
// app.UseHttpsRedirection();



app.MapControllers();

app.Run();

// DateTimeOffset now = DateTimeOffset.Now;

// DateTimeOffset other = DateTimeOffset.Now;
// TimeSpan difference = other - now;
// Console.WriteLine(difference.Days);

// Console.WriteLine(DateTimeOffset.Compare(now, other));

// Console.WriteLine(DateTimeOffset.Now);
// Console.WriteLine(FileService.FilePath);
// var logs = await FileService.LoadLogs();
// foreach (var log in logs)
// {
//     Console.WriteLine(log);
// }

// var logs = await FileService.LoadLogs();

// await LogsController.IsNewDay();

// Console.WriteLine($"Is this moment a new day: {newDay}");

// await FileService.SaveLogs(logs);
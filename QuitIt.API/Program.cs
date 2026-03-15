using QuitIt.API.Models;
using QuitIt.API.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); 
builder.Services.AddScoped<IFileService<Log>, LogsFileService>();
builder.Services.AddScoped<IFileService<Trigger>, TriggersFileService>();
builder.Services.AddCors(options =>
{
   options.AddDefaultPolicy(policy =>
   {
       policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
   });
});

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();
app.UseCors();
app.Run();
using System;
using System.Text.Json;
using QuitIt.API.Models;
namespace QuitIt.API.Services;

public class TriggersFileService : IFileService<Trigger>
{
    public static string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "triggers.json");

    private static JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public async Task SaveData(List<Trigger> triggers)
    {
        string stringifiedTriggers = JsonSerializer.Serialize<List<Trigger>>(triggers, Options);
        await File.WriteAllTextAsync(FilePath, stringifiedTriggers);
    }

    public List<Trigger> LoadData()
    {
        var jsonString = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<Trigger>>(jsonString, Options);
    }
}
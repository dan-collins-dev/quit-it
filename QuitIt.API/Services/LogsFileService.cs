using System;
using System.Text.Json;
using QuitIt.API.Models;

namespace QuitIt.API.Services;

public class LogsFileService : IFileService<Log>
{
    public static string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "logs.json");

    private static JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public async Task SaveData(List<Log> logs)
    {
        string stringifiedLogs = JsonSerializer.Serialize<List<Log>>(logs, Options);
        await File.WriteAllTextAsync(FilePath, stringifiedLogs);
    }

    public List<Log> LoadData()
    {
        var jsonString = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<Log>>(jsonString, Options);
    }
}

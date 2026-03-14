using System;
using System.Text.Json;
using QuitIt.API.Models;

namespace QuitIt.API.Services;

public static class FileService
{
    private static string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "logs.json");

    private static JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static async Task SaveLogs(List<Log> logs)
    {
        string stringifiedLogs = JsonSerializer.Serialize<List<Log>>(logs, Options);
        await File.WriteAllTextAsync(FilePath, stringifiedLogs);
    }

    public static async Task<List<Log>> LoadLogs()
    {
        var jsonString = await File.ReadAllTextAsync(FilePath);
        return JsonSerializer.Deserialize<List<Log>>(jsonString, Options);
    }
}

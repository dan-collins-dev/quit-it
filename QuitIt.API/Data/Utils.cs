using System;
using System.Linq;
using System.Text.Json;
using QuitIt.API.Models;

namespace QuitIt.API.Data;

public static class Utils
{
    private static string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "smokerLogs.json");
    private static JsonSerializerOptions Options = new() {
        PropertyNameCaseInsensitive = true
    };

    public static void CreateDefaultData()
    {
        List<SmokerLog> logs = new List<SmokerLog>()
        {
            new (1, new DateOnly(2026, 2, 21), new DateTime(2026, 2, 25), 1),
            new (2, new DateOnly(2026, 1, 2), new DateTime(2026, 1, 2), 2),
            new (3, new DateOnly(2026, 2, 2), new DateTime(2026, 2, 2), 3),
        };

        SaveSmokerLogs(logs);
    }

    public static void SaveSmokerLogs(List<SmokerLog> logs) {
        string stringifiedLogs = JsonSerializer.Serialize<List<SmokerLog>>(logs, Options);
        File.WriteAllText(FilePath, stringifiedLogs);
    }

    public static List<SmokerLog> GetSmokerLogs()
    {
        string jsonString = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<SmokerLog>>(jsonString, Options);
    }

    public static bool IsNewDay
    {
        get
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);

            string jsonString = File.ReadAllText(FilePath);
            var logs = JsonSerializer.Deserialize<List<SmokerLog>>(jsonString, Options);

            if (logs == null || logs.Count == 0)
            {
                return true;
            }

            DateOnly lastDate = logs.Max(log => log.Date);

            return today > lastDate;
        }
    }
}

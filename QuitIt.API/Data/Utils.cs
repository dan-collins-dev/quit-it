using System;
using System.Text.Json;
using QuitIt.API.Models;

namespace QuitIt.API.Data;

public static class Utils
{
    private static string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "days.json");
    private static JsonSerializerOptions Options = new() {
        PropertyNameCaseInsensitive = true
    };

    public static void CreateDefaultData()
    {
        List<Day> days = new List<Day>()
        {
            new Day(1, new DateOnly(2026, 2, 21), new DateTime(2026, 2, 25), 1),
            new Day(2, new DateOnly(2026, 1, 2), new DateTime(2026, 1, 2), 2),
            new Day(3, new DateOnly(2026, 2, 2), new DateTime(2026, 2, 2), 3),
        };

        string stringifiedDays = JsonSerializer.Serialize<List<Day>>(days, Options);
        File.WriteAllText(FilePath, stringifiedDays);
    }

    public static List<Day> GetDays()
    {
        string jsonString = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<Day>>(jsonString, Options);
    }
}

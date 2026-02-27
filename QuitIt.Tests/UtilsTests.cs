using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using QuitIt.API.Data;
using QuitIt.API.Models;

namespace QuitIt.Tests;

public class UtilsTests
{
    private static string SmokerLogsFilePath => Path.Combine(Directory.GetCurrentDirectory(), "Data", "smokerLogs.json");

    [Fact]
    public static void CreateDefaultData_ShouldCreateThreeDefaultSmokerLogs()
    {
        Utils.CreateDefaultData();
        var logs = Utils.GetSmokerLogs();
        Assert.True(logs.Count == 3);
    }
}
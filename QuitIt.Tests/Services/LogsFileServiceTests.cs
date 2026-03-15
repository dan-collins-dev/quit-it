using QuitIt.API.Models;
using QuitIt.API.Services;

namespace QuitIt.Tests.Services;

public class LogsFileServiceTests
{
    [Fact]
    public async Task SaveData_Then_LoadData_ReturnsSameLogs()
    {
        var service = new LogsFileService();

        LogsFileService.FilePath = Path.GetTempFileName();
        Log log = new Log(Guid.NewGuid(), DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
        Guid newId = log.Id;
        var logs = new List<Log>();
        logs.Add(log);


        await service.SaveData(logs);
        var loadedLogs = service.LoadData();

        Assert.Single(loadedLogs);
        Assert.Equal(newId, loadedLogs[0].Id);
    }
}

using System;
using System.Text.Json;
using Moq;
using QuitIt.API.Models;
using QuitIt.API.Services;

namespace QuitIt.Tests.Services;

public class TriggersFileServiceTests
{
    [Fact]
    public async Task SaveData_Then_LoadData_ReturnsSameTriggers()
    {
        // Arrange
        var service = new TriggersFileService();

        TriggersFileService.FilePath = Path.GetTempFileName();

        Trigger newTrigger = new(Guid.NewGuid());
        Guid newTriggerId = newTrigger.Id;
        newTrigger.Reason = "Stupid things";
        List<Trigger> triggers = [];
        triggers.Add(newTrigger);
        
        await service.SaveData(triggers);
        var loadedTriggers = service.LoadData();

        // Assert
        Assert.Single(loadedTriggers);
        Assert.Equal(newTriggerId, loadedTriggers[0].Id);
    }
}
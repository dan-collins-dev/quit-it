using System;
using QuitIt.API.Services;
using QuitIt.API.Controllers;
using Moq;
using QuitIt.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace QuitIt.Tests.Controllers;

public class LogsControllerTests
{
    [Fact]
    public async Task GetAllLogs_ShouldReturnAllLogs()
    {
        var mockService = new Mock<IFileService<Log>>();

        var logs = new List<Log>
        {
            new Log(Guid.NewGuid(), DateTimeOffset.UtcNow.AddDays(-2).ToUnixTimeMilliseconds())
        };

        mockService.Setup(s => s.LoadData()).Returns(logs);
        mockService.Setup(s => s.SaveData(It.IsAny<List<Log>>()))
                   .Returns(Task.CompletedTask);

        var controller = new LogsController(mockService.Object);

        var result = await controller.GetAllLogs();

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedLogs = Assert.IsType<List<Log>>(okResult.Value);

        Assert.Single(returnedLogs);
    }

    [Fact]
    public async Task GetLogById_ShouldReturnLog_WhenLogExists()
    {
        var mockService = new Mock<IFileService<Log>>();

        var id = Guid.NewGuid();
        var logs = new List<Log>
        {
            new Log(id, DateTimeOffset.UtcNow.AddDays(-2).ToUnixTimeMilliseconds())
        };

        mockService.Setup(s => s.LoadData()).Returns(logs);
        mockService.Setup(s => s.SaveData(It.IsAny<List<Log>>()))
                   .Returns(Task.CompletedTask);

        var controller = new LogsController(mockService.Object);

        var result = await controller.GetLogById(id);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedLogs = Assert.IsType<Log>(okResult.Value);
    }

    [Fact]
    public async Task GetLogById_ShouldReturnBadRequest_WhenLogDoesNotExist()
    {
        var mockService = new Mock<IFileService<Log>>();

        var id = Guid.NewGuid();
        var logs = new List<Log>();

        mockService.Setup(s => s.LoadData()).Returns(logs);
        mockService.Setup(s => s.SaveData(It.IsAny<List<Log>>()))
                   .Returns(Task.CompletedTask);

        var controller = new LogsController(mockService.Object);

        var result = await controller.GetLogById(id);

        var badResult = Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public async Task CreateNewLog_ShouldCreateNewLog_WhenNewDay()
    {
        var mockService = new Mock<IFileService<Log>>();

        var logs = new List<Log>
        {
            new Log(Guid.NewGuid(), DateTimeOffset.UtcNow.AddDays(-2).ToUnixTimeMilliseconds())
        };

        mockService.Setup(s => s.LoadData()).Returns(logs);
        mockService.Setup(s => s.SaveData(It.IsAny<List<Log>>()))
                   .Returns(Task.CompletedTask);

        var controller = new LogsController(mockService.Object);

        var result = await controller.CreateNewLog();

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var newLog = Assert.IsType<Log>(okResult.Value);

        Assert.Equal(2, logs.Count);
    }

    [Fact]
    public async Task CreateNewLog_ShouldIncrementCigCount_WhenSameDay()
    {
        var mockService = new Mock<IFileService<Log>>();
        var logs = new List<Log>
        {
            new Log(Guid.NewGuid(), DateTimeOffset.UtcNow.ToUnixTimeMilliseconds())
        };

        mockService.Setup(s => s.LoadData()).Returns(logs);
        mockService.Setup(s => s.SaveData(It.IsAny<List<Log>>()))
                   .Returns(Task.CompletedTask);

        var controller = new LogsController(mockService.Object);

        var result = await controller.CreateNewLog();

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var sameLog = Assert.IsType<Log>(okResult.Value);
        Assert.Equal(2, sameLog.NumOfCigs);
    }
}

using System;
using QuitIt.API.Services;
using QuitIt.API.Controllers;
using Moq;
using QuitIt.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace QuitIt.Tests.Controllers;

public class TriggersControllerTests
{
    [Fact]
    public async Task GetAllTriggers_ShouldReturnAllTriggers()
    {
        var mockService = new Mock<IFileService<Trigger>>();

        var triggers = new List<Trigger>();
        var newTrigger = new Trigger(Guid.NewGuid());
        newTrigger.Reason = "Some Default Reason";
        triggers.Add(newTrigger);
        
        mockService.Setup(s => s.LoadData()).Returns(triggers);
        mockService.Setup(s => s.SaveData(It.IsAny<List<Trigger>>()))
                   .Returns(Task.CompletedTask);

        var controller = new TriggersController(mockService.Object);

        var result = await controller.GetAllTriggers();

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedTriggers = Assert.IsType<List<Trigger>>(okResult.Value);

        Assert.Single(returnedTriggers);
    }

    [Fact]
    public async Task GetTriggerById_ShouldReturnTrigger_WhenTriggerExists()
    {
        var mockService = new Mock<IFileService<Trigger>>();

        var id = Guid.NewGuid();
        var triggers = new List<Trigger>
        {
            new Trigger(id)
        };

        mockService.Setup(s => s.LoadData()).Returns(triggers);
        mockService.Setup(s => s.SaveData(It.IsAny<List<Trigger>>()))
                   .Returns(Task.CompletedTask);

        var controller = new TriggersController(mockService.Object);


        var result = await controller.GetTriggerById(id);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedTriggers = Assert.IsType<Trigger>(okResult.Value);
    }

    [Fact]
    public async Task GetTriggerById_ShouldReturnBadRequest_WhenTriggerDoesNotExist()
    {
        var mockService = new Mock<IFileService<Trigger>>();

        Trigger trigger = new(Guid.NewGuid());
        Guid triggerId = trigger.Id;
        trigger.Reason = "Some testing reason";
        var triggers = new List<Trigger>
        {
            new Trigger(Guid.NewGuid())
        };

        mockService.Setup(s => s.LoadData()).Returns(triggers);
        mockService.Setup(s => s.SaveData(It.IsAny<List<Trigger>>()))
                   .Returns(Task.CompletedTask);

        var controller = new TriggersController(mockService.Object);

        var result = await controller.GetTriggerById(triggerId);

        var badResult = Assert.IsType<BadRequestResult>(result);
        Assert.NotEqual(triggerId, triggers[0].Id);
    }

    [Fact]
    public async Task UpdateTriggerById_ShouldReturnBadRequest_WhenTriggerDoesNotExist()
    {
        var mockService = new Mock<IFileService<Trigger>>();

        Trigger trigger = new(Guid.NewGuid());
        Guid triggerId = trigger.Id;
        trigger.Reason = "Some testing reason";
        var triggers = new List<Trigger>
        {
            new Trigger(Guid.NewGuid())
        };

        mockService.Setup(s => s.LoadData()).Returns(triggers);
        mockService.Setup(s => s.SaveData(It.IsAny<List<Trigger>>()))
                   .Returns(Task.CompletedTask);

        var controller = new TriggersController(mockService.Object);

        var result = await controller.UpdateTriggerById(triggerId, trigger);

        var badResult = Assert.IsType<BadRequestResult>(result.Result);
        Assert.NotEqual(triggerId, triggers[0].Id);
    }

    [Fact]
    public async Task UpdateTriggerById_ShouldUpdateExistingTrigger_WhenReasonProvided()
    {
        var mockService = new Mock<IFileService<Trigger>>();

        Trigger trigger = new(Guid.NewGuid());
        Guid triggerId = trigger.Id;
        trigger.Reason = "Some testing reason";
        var triggers = new List<Trigger>() { trigger };

        mockService.Setup(s => s.LoadData()).Returns(triggers);
        mockService.Setup(s => s.SaveData(It.IsAny<List<Trigger>>()))
                   .Returns(Task.CompletedTask);

        var controller = new TriggersController(mockService.Object);

        var result = await controller.UpdateTriggerById(triggerId, trigger);

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var existingTrigger = Assert.IsType<Trigger>(okResult.Value);

        Assert.Equal(trigger.Id, existingTrigger.Id);
    }

    [Fact]
    public async Task CreateNewTrigger_ShouldCreateATrigger_WhenReasonProvided()
    {
        var mockService = new Mock<IFileService<Trigger>>();
        
        Trigger trigger = new(Guid.NewGuid());
        Guid triggerId = trigger.Id;
        trigger.Reason = "Some testing reason";
        var triggers = new List<Trigger>() { trigger };

        mockService.Setup(s => s.LoadData()).Returns(triggers);
        mockService.Setup(s => s.SaveData(It.IsAny<List<Trigger>>()))
                   .Returns(Task.CompletedTask);

        var controller = new TriggersController(mockService.Object);

        var result = await controller.CreateNewTrigger(trigger);

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var newTrigger = Assert.IsType<Trigger>(okResult.Value);
    }

    [Fact]
    public async Task CreateNewTrigger_ShouldReturnBadRequest_WhenNoReasonProvided()
    {
        var mockService = new Mock<IFileService<Trigger>>();

        Trigger trigger = new(Guid.NewGuid());
        Guid triggerId = trigger.Id;
        var triggers = new List<Trigger>() { trigger };

        mockService.Setup(s => s.LoadData()).Returns(triggers);
        mockService.Setup(s => s.SaveData(It.IsAny<List<Trigger>>()))
                   .Returns(Task.CompletedTask);

        var controller = new TriggersController(mockService.Object);

        var result = await controller.CreateNewTrigger(trigger);

        var badResult = Assert.IsType<BadRequestResult>(result.Result);
    }

    [Fact]
    public async Task DeleteTrigger_ShouldDeleteTrigger_WhenTriggerExists()
    {
        var mockService = new Mock<IFileService<Trigger>>();

        Trigger trigger = new(Guid.NewGuid());
        Guid triggerId = trigger.Id;
        var triggers = new List<Trigger>() { trigger };

        mockService.Setup(s => s.LoadData()).Returns(triggers);
        mockService.Setup(s => s.SaveData(It.IsAny<List<Trigger>>()))
                   .Returns(Task.CompletedTask);

        var controller = new TriggersController(mockService.Object);

        var result = await controller.DeleteTrigger(triggerId);

        var okResult = Assert.IsType<OkObjectResult>(result.Result);

    }

    [Fact]
    public async Task DeleteTrigger_ShouldReturnBadRequest_WhenTriggerDoesNotExist()
    {
        var mockService = new Mock<IFileService<Trigger>>();

        Trigger trigger = new(Guid.NewGuid());
        Guid triggerId = trigger.Id;
        var triggers = new List<Trigger>();

        mockService.Setup(s => s.LoadData()).Returns(triggers);
        mockService.Setup(s => s.SaveData(It.IsAny<List<Trigger>>()))
                   .Returns(Task.CompletedTask);

        var controller = new TriggersController(mockService.Object);

        var result = await controller.DeleteTrigger(triggerId);

        var badResult = Assert.IsType<BadRequestResult>(result.Result);

    }
}
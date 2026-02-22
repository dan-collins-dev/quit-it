using QuitIt.API.Data;
using QuitIt.API.Models;
namespace QuitIt.Tests;

public class UnitTest1
{
    [Fact]
    public void UtilsGetDays_ShouldReturnData_WhenUtilsCreateDataIsInvoked()
    {
        Utils.CreateDefaultData();
        var data = Utils.GetDays();
        Assert.NotEmpty(data);
    }

    [Fact]
    public void UtilsGetDays()
    {
        var data = Utils.GetDays();
        Assert.NotEmpty(data);
    }
}

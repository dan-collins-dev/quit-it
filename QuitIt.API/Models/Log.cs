namespace QuitIt.API.Models;

public record class Log(Guid Id, long Date)
{
    public int NumOfCigs { get; set; } = 1;
}
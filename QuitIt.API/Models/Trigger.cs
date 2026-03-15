namespace QuitIt.API.Models;

public record class Trigger(Guid Id)
{
    public string? Reason { get; set; }   
}

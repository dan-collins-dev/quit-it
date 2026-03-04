namespace QuitIt.API.Models;

public record class SmokerLog(
    int Id,
    DateOnly Date,
    DateTime Time,
    int NumberOfCigarettes
);
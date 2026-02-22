namespace QuitIt.API.Models;

public record class Day(int Id, DateOnly Date, DateTime Time, int NumberOfCigarettes);
namespace TaskOmatic.Contracts.Dtos;

public record TaskDto(int Id, string Name, string Description, DateTime CreateDateTime, int userId);

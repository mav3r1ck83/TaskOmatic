using TaskOmatic.Contracts.Dtos;

namespace TaskOmatic.Contracts.Responses;

public record GetUsersResponse(List<UserDto> UserDtos);

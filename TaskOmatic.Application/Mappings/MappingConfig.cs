using Mapster;
using TaskOmatic.Contracts.Dtos;
using TaskOmatic.Contracts.Responses;
using TaskOmatic.Domain.Entities;

namespace TaskOmatic.Application.Mappings;

public class MappingConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<List<Task>, GetTasksResponse>
            .NewConfig()
            .Map(dest => dest.TasksDtos, src => src == null 
                ? new List<TaskDto>() : src.Adapt<List<TaskDto>>());

        TypeAdapterConfig<Task, GetTaskByIdResponse>.NewConfig()
            .Map(dest => dest.TaskDto, src => src);
        TypeAdapterConfig<List<User>, GetUsersResponse>.NewConfig()
            .Map(dest => dest.UserDtos, src => src);
    }
}
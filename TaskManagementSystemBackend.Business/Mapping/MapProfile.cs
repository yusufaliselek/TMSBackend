using AutoMapper;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects;
using TaskManagementSystemBackend.DataAccess.Entities;

namespace TaskManagementSystemBackend.Business.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            // User Mapping
            CreateMap<User, UserDto>();
            CreateMap<RegisterDto, User>();
            CreateMap<UpdateUserDto, User>();

            // Organization Mapping
            CreateMap<Organization, OrganizationDto>();
            CreateMap<Organization, CreateOrganizationDto>();
            CreateMap<Organization, UpdateOrganizationDto>();

            // Task Mapping
            CreateMap<TaskBase, TaskDto>();
            CreateMap<CreateTaskDto, TaskBase>();
            CreateMap<UpdateTaskDto, TaskBase>();

            // TaskUpdate Mapping
            CreateMap<TaskUpdate, TaskUpdateDto>();
            CreateMap<CreateTaskUpdateDto, TaskUpdate>();
            CreateMap<UpdateTaskUpdateDto, TaskUpdate>();

            CreateMap<Token, TokenDto>();
        }
    }
}

using AutoMapper;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.Organization;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.Task;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.TaskUpdate;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.Token;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.User;
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
            CreateMap<CreateOrganizationDto, Organization>();
            CreateMap<UpdateOrganizationDto, Organization>();

            // Task Mapping
            CreateMap<OrganizationProjectTask, OrganizationProjectTaskDto>();
            CreateMap<CreateOrganizationProjectTaskDto, OrganizationProjectTask>();
            CreateMap<UpdateOrganizationProjectTaskDto, OrganizationProjectTask>();

            // TaskUpdate Mapping
            CreateMap<OrganizationProjectTaskUpdate, OrganizationProjectTaskUpdateDto>();
            CreateMap<CreateOrganizationProjectTaskUpdateDto, OrganizationProjectTaskUpdate>();
            CreateMap<UpdateOrganizationProjectTaskUpdateDto, OrganizationProjectTaskUpdate>();

            CreateMap<Token, TokenDto>();
        }
    }
}

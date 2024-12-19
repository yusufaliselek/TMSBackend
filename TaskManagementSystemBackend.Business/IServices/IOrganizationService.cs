using TaskManagementSystemBackend.DataAccess.DataTransferObjects.Organization;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.OrganizationRole;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.User;

namespace TaskManagementSystemBackend.DataAccess.IServices
{
    public interface IOrganizationService
    {
        Task<OrganizationDto> GetOrganizationByIdAsync(string organizationId);
        Task<IEnumerable<OrganizationDto>> GetAllOrganizationsAsync();
        Task<OrganizationDto> CreateOrganizationAsync(CreateOrganizationDto organizationDto, string token);
        Task<OrganizationDto> UpdateOrganizationAsync(string organizationId, UpdateOrganizationDto updateOrganizationDto);
        Task<bool> DeleteOrganizationAsync(string organizationId);
        Task<IEnumerable<UserDto>> GetUsersByOrganizationIdAsync(string organizationId);
        Task<UserDto> GetOwnerByOrganizationIdAsync(string organizationId);
        Task<OrganizationRoleDto> GetOrganizationRolesByOrganizationIdAsync(string organizationId);
        Task AddUserToOrganizationAsync(string organizationId, string userId);
        Task RemoveUserFromOrganizationAsync(string organizationId, string userId);
    }

}


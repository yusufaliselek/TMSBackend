using TaskManagementSystemBackend.DataAccess.DataTransferObjects.Organization;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.OrganizationRole;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.User;

namespace TaskManagementSystemBackend.DataAccess.IServices
{
    public interface IOrganizationService
    {
        Task<OrganizationDto> GetOrganizationByIdAsync(int organizationId);
        Task<IEnumerable<OrganizationDto>> GetAllOrganizationsAsync();
        Task<OrganizationDto> CreateOrganizationAsync(CreateOrganizationDto organizationDto);
        Task<OrganizationDto> UpdateOrganizationAsync(int organizationId, UpdateOrganizationDto updateOrganizationDto);
        Task<bool> DeleteOrganizationAsync(int organizationId);
        Task<IEnumerable<UserDto>> GetUsersByOrganizationIdAsync(int organizationId);
        Task<UserDto> GetOwnerByOrganizationIdAsync(int organizationId);
        Task<OrganizationRoleDto> GetOrganizationRolesByOrganizationIdAsync(int organizationId);
        Task AddUserToOrganizationAsync(int organizationId, int userId);
        Task RemoveUserFromOrganizationAsync(int organizationId, int userId);
    }

}


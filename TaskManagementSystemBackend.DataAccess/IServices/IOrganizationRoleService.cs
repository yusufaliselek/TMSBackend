using TaskManagementSystemBackend.DataAccess.DataTransferObjects.OrganizationRole;

namespace TaskManagementSystemBackend.Business.Services
{
    public interface IOrganizationRoleService
    {
        Task<List<OrganizationRoleDto>> GetRolesByOrganizationIdAsync(int organizationId);
        Task<OrganizationRoleDto> GetRoleByIdAsync(int roleId);
        Task CreateOrganizationRoleAsync(CreateOrganizationRoleDto createDto);
        Task UpdateOrganizationRoleAsync(int roleId, UpdateOrganizationRoleDto updateDto);
        Task DeleteOrganizationRoleAsync(int roleId);
    }
}

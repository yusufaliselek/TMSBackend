using TaskManagementSystemBackend.DataAccess.DataTransferObjects.OrganizationRole;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.User;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.UserOrganizationRole;

namespace TaskManagementSystemBackend.Business.Services
{
    public interface IOrganizationUserRoleService
    {
        Task AssignUserToRoleAsync(AssignUserToOrganizationRoleDto assignDto);
        Task RemoveUserFromRoleAsync(RemoveUserFromOrganizationRoleDto removeDto);
        Task<List<UserDto>> GetUsersByRoleIdAsync(int roleId);
        Task<List<OrganizationRoleDto>> GetRolesByUserIdAsync(int userId);
    }
}

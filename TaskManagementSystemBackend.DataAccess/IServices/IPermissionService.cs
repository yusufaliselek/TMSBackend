using TaskManagementSystemBackend.DataAccess.DataTransferObjects.Permission;

namespace TaskManagementSystemBackend.Business.Services
{
    public interface IPermissionService
    {
        Task<List<PermissionDto>> GetAllPermissionsAsync();
        Task<PermissionDto> GetPermissionByIdAsync(int permissionId);
    }
}

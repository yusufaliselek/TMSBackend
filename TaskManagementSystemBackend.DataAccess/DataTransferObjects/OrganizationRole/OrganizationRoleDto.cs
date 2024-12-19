using TaskManagementSystemBackend.DataAccess.DataTransferObjects.Permission;

namespace TaskManagementSystemBackend.DataAccess.DataTransferObjects.OrganizationRole
{
    public class OrganizationRoleDto
    {
        public string Id { get; set; } // Rol ID'si
        public string Name { get; set; } // Rol adı
        public List<PermissionDto> Permissions { get; set; } // Roldeki izinler
    }
}

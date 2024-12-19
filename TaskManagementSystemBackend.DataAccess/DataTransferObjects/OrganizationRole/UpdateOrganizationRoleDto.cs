namespace TaskManagementSystemBackend.DataAccess.DataTransferObjects.OrganizationRole
{
    public class UpdateOrganizationRoleDto
    {
        public string Name { get; set; } // Yeni rol adı
        public List<string> PermissionIds { get; set; } // Güncellenmiş izin ID'leri
    }
}

namespace TaskManagementSystemBackend.DataAccess.DataTransferObjects.OrganizationRole
{
    public class CreateOrganizationRoleDto
    {
        public string OrganizationId { get; set; } // Hangi organizasyona ait olduğu
        public string Name { get; set; } // Rol adı
        public List<int> PermissionIds { get; set; } // Rol için atanacak izinlerin ID'leri
    }
}

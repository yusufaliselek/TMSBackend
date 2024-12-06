namespace TaskManagementSystemBackend.DataAccess.DataTransferObjects.UserOrganizationRole
{
    public class AssignUserToOrganizationRoleDto
    {
        public int UserId { get; set; } // Kullanıcı ID'si
        public int OrganizationRoleId { get; set; } // Organizasyon Rol ID'si
    }
}

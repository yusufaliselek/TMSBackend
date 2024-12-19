namespace TaskManagementSystemBackend.DataAccess.DataTransferObjects.UserOrganizationRole
{
    public class AssignUserToOrganizationRoleDto
    {
        public string UserId { get; set; } // Kullanıcı ID'si
        public string OrganizationRoleId { get; set; } // Organizasyon Rol ID'si
    }
}

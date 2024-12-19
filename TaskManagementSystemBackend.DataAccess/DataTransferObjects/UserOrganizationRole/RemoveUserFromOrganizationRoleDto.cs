namespace TaskManagementSystemBackend.DataAccess.DataTransferObjects.UserOrganizationRole
{
    public class RemoveUserFromOrganizationRoleDto
    {
        public string UserId { get; set; } // Kullanıcı ID'si
        public string OrganizationRoleId { get; set; } // Organizasyon Rol ID'si
    }
}

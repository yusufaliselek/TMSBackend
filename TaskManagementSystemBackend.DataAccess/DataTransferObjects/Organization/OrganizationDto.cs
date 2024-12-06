using TaskManagementSystemBackend.DataAccess.DataTransferObjects.User;

namespace TaskManagementSystemBackend.DataAccess.DataTransferObjects.Organization
{
    public class OrganizationDto
    {
        public int Id { get; set; }  // Organizasyon ID'si
        public string Name { get; set; }  // Organizasyon adı
        public string Description { get; set; }  // Organizasyon açıklaması
        public int OwnerId { get; set; }  // Organizasyon sahibi kullanıcı ID'si
        public string OwnerName { get; set; }  // Organizasyon sahibi kullanıcı adı
        public List<UserDto> Users { get; set; }  // Organizasyona ait kullanıcılar (DTO olarak)
    }

}

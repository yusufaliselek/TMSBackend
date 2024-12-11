namespace TaskManagementSystemBackend.DataAccess.DataTransferObjects.Organization
{
    public class CreateOrganizationDto
    {
        public string Name { get; set; }  // Organizasyon adı
        public string Description { get; set; }  // Organizasyon açıklaması
        public int OwnerId { get; set; }  // Organizasyon sahibi kullanıcı ID'si
    }
}

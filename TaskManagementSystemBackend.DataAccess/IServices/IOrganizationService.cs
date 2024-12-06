using TaskManagementSystemBackend.DataAccess.DataTransferObjects.Organization;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.OrganizationRole;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.User;

namespace TaskManagementSystemBackend.DataAccess.IServices
{
    public interface IOrganizationService
    {
        Task<OrganizationDto> GetOrganizationByIdAsync(int organizationId); // Id'ye göre organizasyon getir
        Task<IEnumerable<OrganizationDto>> GetAllOrganizationsAsync(); // Tüm organizasyonları getir
        Task<OrganizationDto> CreateOrganizationAsync(CreateOrganizationDto organizationDto); // Organizasyon oluştur
        Task<OrganizationDto> UpdateOrganizationAsync(int organizationId, UpdateOrganizationDto updateOrganizationDto); // Organizasyonu güncelle
        Task<bool> DeleteOrganizationAsync(int organizationId); // Organizasyonu sil
        Task<IEnumerable<UserDto>> GetUsersByOrganizationIdAsync(int organizationId);  // Organizasyona ait kullanıcılar
        Task<UserDto> GetOwnerByOrganizationIdAsync(int organizationId);  // Organizasyonun sahibi
        Task<OrganizationRoleDto> GetOrganizationRolesByOrganizationIdAsync(int organizationId);  // Organizasyonun rolü
        Task AddUserToOrganizationAsync(int organizationId, int userId);  // Kullanıcıyı organizasyona ekle
        Task RemoveUserFromOrganizationAsync(int organizationId, int userId);  // Kullanıcıyı organizasyondan çıkar
    }

}


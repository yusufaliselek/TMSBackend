using TaskManagementSystemBackend.DataAccess.DataTransferObjects;

namespace TaskManagementSystemBackend.DataAccess.IServices
{
    public interface IOrganizationService
    {
        Task<OrganizationDto> GetOrganizationByIdAsync(int organizationId);
        Task<IEnumerable<OrganizationDto>> GetAllOrganizationsAsync();
        Task<OrganizationDto> CreateOrganizationAsync(CreateOrganizationDto organizationDto);
        Task<OrganizationDto> UpdateOrganizationAsync(int organizationId, UpdateOrganizationDto updateOrganizationDto);
        Task<bool> DeleteOrganizationAsync(int organizationId);
        Task<IEnumerable<UserDto>> GetUsersByOrganizationIdAsync(int organizationId);  // Organizasyona ait kullanıcılar
    }

}


using TaskManagementSystemBackend.DataAccess.DataTransferObjects.Organization;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.User;

namespace TaskManagementSystemBackend.DataAccess.IServices
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(int userId);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> UpdateUserAsync(int userId, UpdateUserDto updateUserDto, string token);
        Task<bool> DeleteUserAsync(int userId, string token);
        Task<IEnumerable<OrganizationDto>> GetOrganizationsByUserIdAsync(int userId);  // Kullanıcının ait olduğu organizasyonlar
    }

}

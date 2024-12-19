using TaskManagementSystemBackend.DataAccess.DataTransferObjects.Organization;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.User;

namespace TaskManagementSystemBackend.DataAccess.IServices
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(string userId);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> UpdateUserAsync(string userId, UpdateUserDto updateUserDto, string token);
        Task<bool> DeleteUserAsync(string userId, string token);
        Task<IEnumerable<OrganizationDto>> GetOrganizationsByUserIdAsync(string userId);
    }

}

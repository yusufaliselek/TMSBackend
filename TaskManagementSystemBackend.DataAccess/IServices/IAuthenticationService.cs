using TaskManagementSystemBackend.DataAccess.DataTransferObjects;

namespace TaskManagementSystemBackend.DataAccess.IServices
{
    public interface IAuthenticationService
    {
        Task<TokenDto> AuthenticateAsync(LoginDto loginDto);
        Task<TokenDto> RegisterAsync(RegisterDto createUserDto);

        Task<bool> RevokeRefreshTokenAsync(string refreshToken);

        Task<TokenDto> RefreshTokenAsync(string refreshToken);
    }
}

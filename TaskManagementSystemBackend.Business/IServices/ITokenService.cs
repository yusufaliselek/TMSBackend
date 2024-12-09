using TaskManagementSystemBackend.DataAccess.DataTransferObjects.Token;
using TaskManagementSystemBackend.DataAccess.Entities;

namespace TaskManagementSystemBackend.DataAccess.IServices
{
    public interface ITokenService
    {
        TokenDto GenerateToken(User user);
    }

}

using TaskManagementSystemBackend.DataAccess.DataTransferObjects;
using TaskManagementSystemBackend.DataAccess.Entities;

namespace TaskManagementSystemBackend.DataAccess.IServices
{
    public interface ITokenService
    {
        TokenDto GenerateToken(User user);
    }

}

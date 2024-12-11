using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using TaskManagementSystemBackend.DataAccess;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.Organization;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.User;
using TaskManagementSystemBackend.DataAccess.IServices;

namespace TaskManagementSystemBackend.Business.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private bool IsTokenUserVerify(int userId, string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            if (jwtToken == null) return false;
            return int.Parse(jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub).Value) == userId;
        }

        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            try
            {
                var user = await _context.Users.FindAsync(userId);
                if (user == null) return null;

                return _mapper.Map<UserDto>(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"Kullanıcı getirilirken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            try
            {
                var users = await _context.Users.ToListAsync();
                return _mapper.Map<IEnumerable<UserDto>>(users);
            }
            catch (Exception ex)
            {
                throw new Exception($"Kullanıcılar alınırken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<UserDto> UpdateUserAsync(int userId, UpdateUserDto updateUserDto, string token)
        {
            try
            {
                var isUserTokenVerify = IsTokenUserVerify(userId, token);
                if (!isUserTokenVerify) throw new UnauthorizedAccessException("Token yetkisiz.");
                var user = await _context.Users.FindAsync(userId);
                if (user == null) return null;

                _mapper.Map(updateUserDto, user);
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return _mapper.Map<UserDto>(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"Kullanıcı güncellenirken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<bool> DeleteUserAsync(int userId, string token)
        {
            try
            {
                var isUserTokenVerify = IsTokenUserVerify(userId, token);
                if (!isUserTokenVerify) throw new UnauthorizedAccessException("Token yetkisiz.");

                var user = await _context.Users.FindAsync(userId);
                if (user == null) throw new UnauthorizedAccessException("Kullanıcı bulunamadı.");

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Kullanıcı silinirken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<IEnumerable<OrganizationDto>> GetOrganizationsByUserIdAsync(int userId)
        {
            try
            {
                var user = await _context.Users
                    .Include(u => u.Organizations)
                    .FirstOrDefaultAsync(u => u.Id == userId);

                if (user == null) return null;

                return _mapper.Map<IEnumerable<OrganizationDto>>(user.Organizations);
            }
            catch (Exception ex)
            {
                throw new Exception($"Kullanıcının organizasyonları alınırken bir hata oluştu: {ex.Message}");
            }
        }
    }
}

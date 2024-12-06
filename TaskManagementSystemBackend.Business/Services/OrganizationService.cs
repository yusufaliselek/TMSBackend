using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystemBackend.DataAccess;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects;
using TaskManagementSystemBackend.DataAccess.Entities;
using TaskManagementSystemBackend.DataAccess.IServices;

namespace TaskManagementSystemBackend.Business.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public OrganizationService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrganizationDto> GetOrganizationByIdAsync(int organizationId)
        {
            try
            {
                var organization = await _context.Organizations.FindAsync(organizationId);
                if (organization == null) return null;

                return _mapper.Map<OrganizationDto>(organization);
            }
            catch (Exception ex)
            {
                throw new Exception($"Organizasyonu getirirken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<IEnumerable<OrganizationDto>> GetAllOrganizationsAsync()
        {
            try
            {
                var organizations = await _context.Organizations.ToListAsync();
                return _mapper.Map<IEnumerable<OrganizationDto>>(organizations);
            }
            catch (Exception ex)
            {
                throw new Exception($"Organizasyonları getirirken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<OrganizationDto> CreateOrganizationAsync(CreateOrganizationDto organizationDto)
        {
            try
            {
                var organization = _mapper.Map<Organization>(organizationDto);
                await _context.Organizations.AddAsync(organization);
                await _context.SaveChangesAsync();
                return _mapper.Map<OrganizationDto>(organization);
            }
            catch (Exception ex)
            {
                throw new Exception($"Organizasyon oluşturulurken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<OrganizationDto> UpdateOrganizationAsync(int organizationId, UpdateOrganizationDto updateOrganizationDto)
        {
            try
            {
                var organization = await _context.Organizations.FindAsync(organizationId);
                if (organization == null) return null;

                _mapper.Map(updateOrganizationDto, organization);
                _context.Organizations.Update(organization);
                await _context.SaveChangesAsync();
                return _mapper.Map<OrganizationDto>(organization);
            }
            catch (Exception ex)
            {
                throw new Exception($"Organizasyon güncellenirken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<bool> DeleteOrganizationAsync(int organizationId)
        {
            try
            {
                var organization = await _context.Organizations.FindAsync(organizationId);
                if (organization == null) return false;

                _context.Organizations.Remove(organization);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Organizasyon silinirken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<IEnumerable<UserDto>> GetUsersByOrganizationIdAsync(int organizationId)
        {
            try
            {
                var organization = await _context.Organizations.FindAsync(organizationId);
                if (organization == null)
                {
                    throw new Exception("Organizasyon bulunamadı");
                }

                var userOrganizations = await _context.UserOrganizations.Where(uo => uo.OrganizationId == organizationId).ToListAsync();
                var users = new List<User>();
                foreach (var user in userOrganizations)
                {
                    var userEntity = await _context.Users.FindAsync(user.UserId);
                    users.Add(userEntity);
                }

                return _mapper.Map<IEnumerable<UserDto>>(users);
            }
            catch (Exception ex)
            {
                throw new Exception($"Kullanıcılar alınırken bir hata oluştu: {ex.Message}");
            }
        }
    }
}

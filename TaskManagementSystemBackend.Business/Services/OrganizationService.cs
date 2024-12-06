﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystemBackend.DataAccess;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.Organization;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.OrganizationRole;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.User;
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
                    if (userEntity == null) continue;
                    users.Add(userEntity);
                }

                return _mapper.Map<IEnumerable<UserDto>>(users);
            }
            catch (Exception ex)
            {
                throw new Exception($"Kullanıcılar alınırken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<UserDto> GetOwnerByOrganizationIdAsync(int organizationId)
        {
            try
            {
                var organization = await _context.Organizations.FindAsync(organizationId);
                if (organization == null) throw new Exception("Organizasyon bulunamadı");

                var owner = await _context.Users.FindAsync(organization.OwnerId);
                if (owner == null) throw new Exception("Organizasyon sahibi bulunamadı");

                return _mapper.Map<UserDto>(owner);
            }
            catch (Exception ex)
            {
                throw new Exception($"Organizasyon sahibi alınırken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task<OrganizationRoleDto> GetOrganizationRolesByOrganizationIdAsync(int organizationId)
        {
            try
            {
                var roles = await _context.OrganizationRoles
                    .Where(or => or.OrganizationId == organizationId)
                    .ToListAsync();

                return _mapper.Map<OrganizationRoleDto>(roles);
            }
            catch (Exception ex)
            {
                throw new Exception($"Organizasyona ait roller alınırken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task AddUserToOrganizationAsync(int organizationId, int userId)
        {
            try
            {
                var organization = await _context.Organizations.FindAsync(organizationId);
                if (organization == null) throw new Exception("Organizasyon bulunamadı");

                var userExists = await _context.Users.AnyAsync(u => u.Id == userId);
                if (!userExists) throw new Exception("Kullanıcı bulunamadı");

                var userOrganizationExists = await _context.UserOrganizations
                    .AnyAsync(uo => uo.OrganizationId == organizationId && uo.UserId == userId);

                if (userOrganizationExists) throw new Exception("Kullanıcı zaten organizasyona eklenmiş");

                var userOrganization = new UserOrganization
                {
                    OrganizationId = organizationId,
                    UserId = userId
                };

                await _context.UserOrganizations.AddAsync(userOrganization);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Kullanıcı organizasyona eklenirken bir hata oluştu: {ex.Message}");
            }
        }

        public async Task RemoveUserFromOrganizationAsync(int organizationId, int userId)
        {
            try
            {
                var userOrganization = await _context.UserOrganizations
                    .FirstOrDefaultAsync(uo => uo.OrganizationId == organizationId && uo.UserId == userId);

                if (userOrganization == null) throw new Exception("Kullanıcı organizasyonda bulunamadı");

                _context.UserOrganizations.Remove(userOrganization);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Kullanıcı organizasyondan çıkarılırken bir hata oluştu: {ex.Message}");
            }
        }
    }
}

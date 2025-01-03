﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystemBackend.API.Attributes;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.Organization;
using TaskManagementSystemBackend.DataAccess.IServices;

namespace TaskManagementSystemBackend.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var organizations = await _organizationService.GetAllOrganizationsAsync();
                return Ok(organizations);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Bir hata oluştu", details = ex.Message });
            }
        }

        [OrganizationUserValidation]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var organization = await _organizationService.GetOrganizationByIdAsync(id);
                if (organization == null) return NotFound(new { message = "Organizasyon bulunamadı." });
                return Ok(organization);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Bir hata oluştu", details = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrganizationDto organizationDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(new { message = "Geçersiz model verisi.", details = ModelState });
                var createdOrganization = await _organizationService.CreateOrganizationAsync(organizationDto, Request.Headers["Authorization"].SingleOrDefault()?.Split(" ").Last());
                return CreatedAtAction(nameof(GetById), new { id = createdOrganization.Id }, createdOrganization);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Bir hata oluştu", details = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [OrganizationUserValidation]
        [PermissionRequirement("EditOrganization")]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateOrganizationDto updateOrganizationDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(new { message = "Geçersiz model verisi.", details = ModelState });

                var updatedOrganization = await _organizationService.UpdateOrganizationAsync(id, updateOrganizationDto);
                if (updatedOrganization == null) return NotFound(new { message = "Organizasyon bulunamadı." });
                return Ok(updatedOrganization);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Bir hata oluştu", details = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [OrganizationUserValidation]
        [PermissionRequirement("DeleteOrganization")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var result = await _organizationService.DeleteOrganizationAsync(id);
                if (!result) return NotFound(new { message = "Organizasyon bulunamadı veya silinemedi." });
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Bir hata oluştu", details = ex.Message });
            }
        }

        [HttpGet("{id}/users")]
        [OrganizationUserValidation]
        [PermissionRequirement("ViewOrganizationUsers")]
        public async Task<IActionResult> GetUsersByOrganizationId(string id)
        {
            try
            {
                var users = await _organizationService.GetUsersByOrganizationIdAsync(id);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Kullanıcılar alınırken bir hata oluştu", details = ex.Message });
            }
        }

        [HttpGet("{id}/owner")]
        [OrganizationUserValidation]
        public async Task<IActionResult> GetOwnerByOrganizationId(string id)
        {
            try
            {
                var owner = await _organizationService.GetOwnerByOrganizationIdAsync(id);
                if (owner == null) return NotFound(new { message = "Organizasyon sahibi bulunamadı." });
                return Ok(owner);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Sahibi alınırken bir hata oluştu", details = ex.Message });
            }
        }

        [HttpGet("{id}/roles")]
        [OrganizationUserValidation]
        public async Task<IActionResult> GetRolesByOrganizationId(string id)
        {
            try
            {
                var roles = await _organizationService.GetOrganizationRolesByOrganizationIdAsync(id);
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Roller alınırken bir hata oluştu", details = ex.Message });
            }
        }

        [HttpPost("{id}/users/{userId}")]
        [OrganizationUserValidation]
        [PermissionRequirement("AddUserToOrganization")]
        public async Task<IActionResult> AddUserToOrganization(string id, string userId)
        {
            try
            {
                await _organizationService.AddUserToOrganizationAsync(id, userId);
                return Ok(new { message = "Kullanıcı başarıyla organizasyona eklendi." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Kullanıcı eklenirken bir hata oluştu", details = ex.Message });
            }
        }

        [HttpDelete("{id}/users/{userId}")]
        [OrganizationUserValidation]
        [PermissionRequirement("RemoveUserFromOrganization")]
        public async Task<IActionResult> RemoveUserFromOrganization(string id, string userId)
        {
            try
            {
                await _organizationService.RemoveUserFromOrganizationAsync(id, userId);
                return Ok(new { message = "Kullanıcı organizasyondan başarıyla çıkarıldı." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Kullanıcı çıkarılırken bir hata oluştu", details = ex.Message });
            }
        }
    }
}

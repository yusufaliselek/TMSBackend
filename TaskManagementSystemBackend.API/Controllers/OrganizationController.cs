using Microsoft.AspNetCore.Mvc;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects;
using TaskManagementSystemBackend.DataAccess.IServices;

namespace TaskManagementSystemBackend.API.Controllers
{
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
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

                var createdOrganization = await _organizationService.CreateOrganizationAsync(organizationDto);
                return CreatedAtAction(nameof(GetById), new { id = createdOrganization.Id }, createdOrganization);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Bir hata oluştu", details = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateOrganizationDto updateOrganizationDto)
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
        public async Task<IActionResult> Delete(int id)
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
    }
}

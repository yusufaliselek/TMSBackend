using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.TaskUpdate;
using TaskManagementSystemBackend.DataAccess.IServices;

namespace TaskManagementSystemBackend.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationProjectTaskUpdateController : ControllerBase
    {
        private readonly IOrganizationProjectTaskUpdateService _taskUpdateService;

        public OrganizationProjectTaskUpdateController(IOrganizationProjectTaskUpdateService taskUpdateService)
        {
            _taskUpdateService = taskUpdateService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskUpdate(int id)
        {
            try
            {
                var taskUpdate = await _taskUpdateService.GetTaskUpdateByIdAsync(id);
                return Ok(taskUpdate);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Task güncellemesi bulunamadı." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Bir hata oluştu", details = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTaskUpdates()
        {
            try
            {
                var taskUpdates = await _taskUpdateService.GetAllTaskUpdatesAsync();
                return Ok(taskUpdates);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Bir hata oluştu", details = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskUpdate([FromBody] CreateOrganizationProjectTaskUpdateDto createTaskUpdateDto)
        {
            try
            {
                var taskUpdate = await _taskUpdateService.CreateTaskUpdateAsync(createTaskUpdateDto);
                return CreatedAtAction(nameof(GetTaskUpdate), new { id = taskUpdate.Id }, taskUpdate);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Bir hata oluştu", details = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskUpdate(int id, [FromBody] UpdateOrganizationProjectTaskUpdateDto updateTaskUpdateDto)
        {
            try
            {
                var updatedTaskUpdate = await _taskUpdateService.UpdateTaskUpdateAsync(id, updateTaskUpdateDto);
                return Ok(updatedTaskUpdate);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Task güncellemesi bulunamadı." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Bir hata oluştu", details = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskUpdate(int id)
        {
            try
            {
                var result = await _taskUpdateService.DeleteTaskUpdateAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Task güncellemesi bulunamadı." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Bir hata oluştu", details = ex.Message });
            }
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystemBackend.API.Attributes;
using TaskManagementSystemBackend.DataAccess.DataTransferObjects.Task;
using TaskManagementSystemBackend.DataAccess.IServices;

namespace TaskManagementSystemBackend.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationProjectTaskController : ControllerBase
    {
        private readonly IOrganizationProjectTaskService _taskService;

        public OrganizationProjectTaskController(IOrganizationProjectTaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("{taskId}")]
        public async Task<IActionResult> GetTaskById(int taskId)
        {
            try
            {
                var task = await _taskService.GetTaskByIdAsync(taskId);
                if (task == null)
                    return NotFound(new { message = "Görev bulunamadı." });

                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Bir hata oluştu", details = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var tasks = await _taskService.GetAllTasksAsync();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Bir hata oluştu", details = ex.Message });
            }
        }

        [HttpPost]
        [PermissionRequirement("CreateTask")]
        public async Task<IActionResult> CreateTask([FromBody] CreateOrganizationProjectTaskDto createTaskDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var createdTask = await _taskService.CreateTaskAsync(createTaskDto);
                return CreatedAtAction(nameof(GetTaskById), new { taskId = createdTask.Id }, createdTask);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Bir hata oluştu", details = ex.Message });
            }
        }

        [HttpPut("{taskId}")]
        [PermissionRequirement("EditTask")]
        public async Task<IActionResult> UpdateTask(int taskId, [FromBody] UpdateOrganizationProjectTaskDto updateTaskDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updatedTask = await _taskService.UpdateTaskAsync(taskId, updateTaskDto);
                if (updatedTask == null)
                    return NotFound(new { message = "Görev bulunamadı" });

                return Ok(updatedTask);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Bir hata oluştu", details = ex.Message });
            }
        }

        [HttpDelete("{taskId}")]
        [PermissionRequirement("DeleteTask")]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            try
            {
                var result = await _taskService.DeleteTaskAsync(taskId);
                if (!result)
                    return NotFound(new { message = "Görev bulunamadı veya silinemedi" });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Bir hata oluştu", details = ex.Message });
            }
        }
    }
}

using TaskManagementSystemBackend.DataAccess.DataTransferObjects.Task;

namespace TaskManagementSystemBackend.DataAccess.IServices
{
    public interface IOrganizationProjectTaskService
    {
        Task<OrganizationProjectTaskDto> GetTaskByIdAsync(string taskId);
        Task<IEnumerable<OrganizationProjectTaskDto>> GetAllTasksAsync();
        Task<OrganizationProjectTaskDto> CreateTaskAsync(CreateOrganizationProjectTaskDto createTaskDto);
        Task<OrganizationProjectTaskDto> UpdateTaskAsync(string taskId, UpdateOrganizationProjectTaskDto updateTaskDto);
        Task<bool> DeleteTaskAsync(string taskId);
        Task<IEnumerable<OrganizationProjectTaskDto>> GetTasksByUserIdAsync(string userId);
    }

}

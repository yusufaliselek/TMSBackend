using TaskManagementSystemBackend.DataAccess.DataTransferObjects.Task;

namespace TaskManagementSystemBackend.DataAccess.IServices
{
    public interface IOrganizationProjectTaskService
    {
        Task<OrganizationProjectTaskDto> GetTaskByIdAsync(int taskId);
        Task<IEnumerable<OrganizationProjectTaskDto>> GetAllTasksAsync();
        Task<OrganizationProjectTaskDto> CreateTaskAsync(CreateOrganizationProjectTaskDto createTaskDto);
        Task<OrganizationProjectTaskDto> UpdateTaskAsync(int taskId, UpdateOrganizationProjectTaskDto updateTaskDto);
        Task<bool> DeleteTaskAsync(int taskId);
        Task<IEnumerable<OrganizationProjectTaskDto>> GetTasksByUserIdAsync(int userId);
    }

}

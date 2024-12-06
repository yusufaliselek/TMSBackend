using TaskManagementSystemBackend.DataAccess.DataTransferObjects;

namespace TaskManagementSystemBackend.DataAccess.IServices
{
    public interface ITaskService
    {
        Task<TaskDto> GetTaskByIdAsync(int taskId);
        Task<IEnumerable<TaskDto>> GetAllTasksAsync();
        Task<TaskDto> CreateTaskAsync(CreateTaskDto createTaskDto);
        Task<TaskDto> UpdateTaskAsync(int taskId, UpdateTaskDto updateTaskDto);
        Task<bool> DeleteTaskAsync(int taskId);
        Task<IEnumerable<TaskDto>> GetTasksByUserIdAsync(int userId);
    }

}

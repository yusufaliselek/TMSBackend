using TaskManagementSystemBackend.DataAccess.DataTransferObjects;

namespace TaskManagementSystemBackend.DataAccess.IServices
{
    public interface ITaskUpdateService
    {
        Task<TaskUpdateDto> GetTaskUpdateByIdAsync(int taskUpdateId);
        Task<IEnumerable<TaskUpdateDto>> GetAllTaskUpdatesAsync();
        Task<TaskUpdateDto> CreateTaskUpdateAsync(CreateTaskUpdateDto createTaskUpdateDto);
        Task<TaskUpdateDto> UpdateTaskUpdateAsync(int taskUpdateId, UpdateTaskUpdateDto updateTaskUpdateDto);
        Task<bool> DeleteTaskUpdateAsync(int taskUpdateId);
    }

}

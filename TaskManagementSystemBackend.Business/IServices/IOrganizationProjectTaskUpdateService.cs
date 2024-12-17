using TaskManagementSystemBackend.DataAccess.DataTransferObjects.TaskUpdate;

namespace TaskManagementSystemBackend.DataAccess.IServices
{
    public interface IOrganizationProjectTaskUpdateService
    {
        Task<OrganizationProjectTaskUpdateDto> GetTaskUpdateByIdAsync(int taskUpdateId);
        Task<IEnumerable<OrganizationProjectTaskUpdateDto>> GetAllTaskUpdatesAsync();
        Task<OrganizationProjectTaskUpdateDto> CreateTaskUpdateAsync(CreateOrganizationProjectTaskUpdateDto createTaskUpdateDto);
        Task<OrganizationProjectTaskUpdateDto> UpdateTaskUpdateAsync(int taskUpdateId, UpdateOrganizationProjectTaskUpdateDto updateTaskUpdateDto);
        Task<bool> DeleteTaskUpdateAsync(int taskUpdateId);
    }

}

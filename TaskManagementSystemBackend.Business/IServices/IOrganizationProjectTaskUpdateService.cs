using TaskManagementSystemBackend.DataAccess.DataTransferObjects.TaskUpdate;

namespace TaskManagementSystemBackend.DataAccess.IServices
{
    public interface IOrganizationProjectTaskUpdateService
    {
        Task<OrganizationProjectTaskUpdateDto> GetTaskUpdateByIdAsync(string taskUpdateId);
        Task<IEnumerable<OrganizationProjectTaskUpdateDto>> GetAllTaskUpdatesAsync();
        Task<OrganizationProjectTaskUpdateDto> CreateTaskUpdateAsync(CreateOrganizationProjectTaskUpdateDto createTaskUpdateDto);
        Task<OrganizationProjectTaskUpdateDto> UpdateTaskUpdateAsync(string taskUpdateId, UpdateOrganizationProjectTaskUpdateDto updateTaskUpdateDto);
        Task<bool> DeleteTaskUpdateAsync(string taskUpdateId);
    }

}

using TaskManagementSystemBackend.DataAccess.Entities;

namespace TaskManagementSystemBackend.DataAccess.DataTransferObjects.TaskUpdate
{
    public class OrganizationProjectTaskUpdateDto
    {
        public string Id { get; set; }
        public string TaskId { get; set; }
        public OrganizationProjectTaskStatus OldStatus { get; set; }
        public OrganizationProjectTaskStatus NewStatus { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Comment { get; set; }
    }

}

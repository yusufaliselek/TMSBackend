using TaskManagementSystemBackend.DataAccess.Entities;

namespace TaskManagementSystemBackend.DataAccess.DataTransferObjects.Task
{
    public class OrganizationProjectTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DueDate { get; set; }
        public OrganizationProjectTaskStatus Status { get; set; }
        public OrganizationProjectTaskPriority Priority { get; set; }
        public int OrganizationProjectTaskCategoryId { get; set; }
        public int UserId { get; set; }
        public Entities.User User { get; set; }
    }
}

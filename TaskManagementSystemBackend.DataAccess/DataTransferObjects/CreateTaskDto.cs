namespace TaskManagementSystemBackend.DataAccess.DataTransferObjects
{
    public class CreateTaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public Entities.TaskStatus Status { get; set; }
        public int UserId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystemBackend.DataAccess.Entities
{
    public class TaskUpdate : Base
    {
        [Required]
        public int TaskId { get; set; }

        [Required]
        public TaskStatus OldStatus { get; set; }

        [Required]
        public TaskStatus NewStatus { get; set; }

        [MaxLength(1000)]
        public string Comment { get; set; }
    }
}

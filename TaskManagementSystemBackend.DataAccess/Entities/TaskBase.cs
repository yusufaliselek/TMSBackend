using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystemBackend.DataAccess.Entities
{
    public class TaskBase : Base
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        [Required]
        public TaskStatus Status { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public User User { get; set; }
    }

    public enum TaskStatus
    {
        Pending,    // Beklemede
        InProgress, // Devam ediyor
        Completed,  // Tamamlandı
        Archived    // Arşivlendi
    }
}

using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystemBackend.DataAccess.Entities
{
    public class OrganizationProjectTask : Base
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        [Required]
        public OrganizationProjectTaskStatus Status { get; set; }

        [Required]
        public OrganizationProjectTaskPriority Priority { get; set; }

        [Required]
        public int RowNumber { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public string OrganizationProjectTaskCategoryId { get; set; }

        [Required]
        public OrganizationProjectTaskCategory OrganizationProjectTaskCategory { get; set; }
    }

    public enum OrganizationProjectTaskStatus
    {
        Pending,    // Beklemede
        InProgress, // Devam ediyor - İşlemde
        Completed,  // Tamamlandı
        Archived    // Arşiv - Pasif
    }
    public enum OrganizationProjectTaskPriority
    {
        Low,    // Düşük
        Medium, // Orta
        High    // Yüksek
    }
}

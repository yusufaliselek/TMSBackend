using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystemBackend.DataAccess.Entities
{
    public class OrganizationProjectTaskUpdate : Base
    {
        [Required]
        public int TaskId { get; set; }

        [Required]
        public OrganizationProjectTaskStatus OldStatus { get; set; }

        [Required]
        public OrganizationProjectTaskStatus NewStatus { get; set; }

        [MaxLength(1000)]
        public string Comment { get; set; }
    }
}

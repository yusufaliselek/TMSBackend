using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystemBackend.DataAccess.Entities
{
    public class OrganizationUser : Base
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int OrganizationId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystemBackend.DataAccess.Entities
{
    public class OrganizationUser : Base
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string OrganizationId { get; set; }
    }
}

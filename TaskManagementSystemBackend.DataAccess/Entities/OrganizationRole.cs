using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystemBackend.DataAccess.Entities
{
    public class OrganizationRole: Base
    {
        public string OrganizationId { get; set; }
        public string Name { get; set; }

        public Organization Organization { get; set; }
        public ICollection<OrganizationUserRole> UserOrganizationRoles { get; set; }
        public ICollection<OrganizationRolePermission> OrganizationRolePermissions { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystemBackend.DataAccess.Entities
{
    public class OrganizationRolePermission: Base
    {
        public int OrganizationRoleId { get; set; }
        public int PermissionId { get; set; }
        public OrganizationRole OrganizationRole { get; set; }
        public Permission Permission { get; set; }
    }
}

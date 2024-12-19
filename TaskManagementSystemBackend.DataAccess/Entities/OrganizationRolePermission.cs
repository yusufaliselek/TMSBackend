using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystemBackend.DataAccess.Entities
{
    public class OrganizationRolePermission: Base
    {
        public string OrganizationRoleId { get; set; }
        public string PermissionId { get; set; }
        public OrganizationRole OrganizationRole { get; set; }
        public Permission Permission { get; set; }
    }
}

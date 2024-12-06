using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystemBackend.DataAccess.Entities
{
    public class UserOrganizationRole: Base
    {
        public int UserId { get; set; }
        public int OrganizationRoleId { get; set; }

        public User User { get; set; } // Kullanıcı ile ilişki
        public OrganizationRole OrganizationRole { get; set; } // Organizasyon rolü ile ilişki
    }

}

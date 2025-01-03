﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystemBackend.DataAccess.Entities
{
    public class OrganizationUserRole: Base
    {
        public string UserId { get; set; }
        public string OrganizationRoleId { get; set; }

        public User User { get; set; }
        public OrganizationRole OrganizationRole { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystemBackend.DataAccess.Entities;

namespace TaskManagementSystemBackend.DataAccess.DataTransferObjects.OrganizationProject
{
    public class CreateOrganizationProjectDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int OrganizationId { get; set; }
    }
}

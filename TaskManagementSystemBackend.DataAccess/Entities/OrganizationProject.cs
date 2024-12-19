using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystemBackend.DataAccess.Entities
{
    public class OrganizationProject: Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public ICollection<OrganizationProjectTaskCategory> OrganizationProjectTaskCategories { get; set; }
        public ICollection<OrganizationProjectTask> OrganizationProjectTasks { get; set; }
    }
}

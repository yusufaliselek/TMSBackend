using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystemBackend.DataAccess.Entities
{
    public class OrganizationProjectTaskCategory: Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ColumnNumber { get; set; }
        public int OrganizationProjectId { get; set; }
        public OrganizationProject OrganizationProject { get; set; }
        public ICollection<OrganizationProjectTask> OrganizationProjectTasks { get; set; }
    }
}

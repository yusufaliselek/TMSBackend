using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystemBackend.DataAccess.DataTransferObjects.OrganizationProjectTaskCategory
{
    public class CreateOrganizationProjectTaskCategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int OrganizationProjectId { get; set; }
    }
}

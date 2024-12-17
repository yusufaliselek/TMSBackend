using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystemBackend.DataAccess.DataTransferObjects.OrganizationProject
{
    public class OrganizationProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OrganizationId { get; set; }
        public Entities.Organization Organization { get; set; }
    }
}

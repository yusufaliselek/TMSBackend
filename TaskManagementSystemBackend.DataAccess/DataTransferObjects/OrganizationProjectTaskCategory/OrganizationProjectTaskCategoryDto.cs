
namespace TaskManagementSystemBackend.DataAccess.DataTransferObjects.OrganizationProjectTaskCategory
{
    public class OrganizationProjectTaskCategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ColumnNumber { get; set; }
        public int OrganizationProjectId { get; set; }
    }
}

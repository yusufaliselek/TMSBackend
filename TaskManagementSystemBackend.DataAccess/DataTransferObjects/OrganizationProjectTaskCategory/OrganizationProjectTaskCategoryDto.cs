
namespace TaskManagementSystemBackend.DataAccess.DataTransferObjects.OrganizationProjectTaskCategory
{
    public class OrganizationProjectTaskCategoryDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ColumnNumber { get; set; }
        public string OrganizationProjectId { get; set; }
    }
}

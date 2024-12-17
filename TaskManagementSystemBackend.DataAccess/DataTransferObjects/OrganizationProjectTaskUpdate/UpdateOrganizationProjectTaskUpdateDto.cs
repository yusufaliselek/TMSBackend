﻿using TaskManagementSystemBackend.DataAccess.Entities;

namespace TaskManagementSystemBackend.DataAccess.DataTransferObjects.TaskUpdate
{
    public class UpdateOrganizationProjectTaskUpdateDto
    {
        public int TaskId { get; set; }
        public OrganizationProjectTaskStatus OldStatus { get; set; }
        public OrganizationProjectTaskStatus NewStatus { get; set; }
        public string Comment { get; set; }
    }
}
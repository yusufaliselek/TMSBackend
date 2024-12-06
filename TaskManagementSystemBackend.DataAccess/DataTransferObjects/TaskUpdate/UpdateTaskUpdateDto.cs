using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystemBackend.DataAccess.DataTransferObjects.TaskUpdate
{
    public class UpdateTaskUpdateDto
    {
        public int TaskId { get; set; }
        public Entities.TaskStatus OldStatus { get; set; }
        public Entities.TaskStatus NewStatus { get; set; }
        public string Comment { get; set; }
    }
}

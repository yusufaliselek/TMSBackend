namespace TaskManagementSystemBackend.DataAccess.DataTransferObjects.TaskUpdate
{
    public class TaskUpdateDto
    {
        public int Id { get; set; }  // Güncelleme ID'si
        public int TaskId { get; set; }  // Güncellenen görev ID'si
        public Entities.TaskStatus OldStatus { get; set; }  // Eski görev durumu
        public Entities.TaskStatus NewStatus { get; set; }  // Yeni görev durumu
        public DateTime UpdatedAt { get; set; }  // Güncelleme tarihi
        public string Comment { get; set; }  // Güncelleme açıklaması
    }

}

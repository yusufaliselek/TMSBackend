namespace TaskManagementSystemBackend.DataAccess.DataTransferObjects.Task
{
    public class UpdateTaskDto
    {
        public string Title { get; set; }  // Görev başlığı
        public string Description { get; set; }  // Görev açıklaması
        public DateTime? DueDate { get; set; }  // Görev bitiş tarihi (isteğe bağlı)
        public Entities.TaskStatus Status { get; set; }  // Görev durumu
    }
}

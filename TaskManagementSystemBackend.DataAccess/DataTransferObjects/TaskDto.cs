namespace TaskManagementSystemBackend.DataAccess.DataTransferObjects
{
    public class TaskDto
    {
        public int Id { get; set; }  // Görev ID'si
        public string Title { get; set; }  // Görev başlığı
        public string Description { get; set; }  // Görev açıklaması
        public DateTime CreatedAt { get; set; }  // Görev oluşturulma tarihi
        public DateTime? DueDate { get; set; }  // Görev bitiş tarihi (isteğe bağlı)
        public Entities.TaskStatus Status { get; set; }  // Görev durumu
        public int UserId { get; set; }  // Görevi oluşturan kullanıcı ID'si
    }
}

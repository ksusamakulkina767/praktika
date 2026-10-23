namespace TaskManagerApp.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }      // Название задачи
        public string Status { get; set; }     // Статус
    }
}
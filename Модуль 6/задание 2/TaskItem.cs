namespace Модуль_6
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;       // Название задачи
        public string Description { get; set; } = string.Empty; // Описание
        public bool IsCompleted { get; set; }                   // Статус выполнения
    }
}
namespace задание_2
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;       // Название книги
        public string Author { get; set; } = string.Empty;      // Автор
        public string Genre { get; set; } = string.Empty;       // Жанр
        public bool IsRented { get; set; }                      // Статус: арендована (true) или свободна (false)
        public string RentedBy { get; set; } = string.Empty;    // Кому выдана (имя читателя)
    }
}
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;

namespace задание_2
{
    // Главное окно библиотеки
    public partial class MainWindow : Window
    {
        // Связь с базой данных
        private readonly AppDbContext _context = new();

        public MainWindow()
        {
            InitializeComponent();
            _context.Database.EnsureCreated(); // если базы нет — создаём
            RefreshGrid();                     // показываем книги в таблице
        }

        // Показать книги в таблице (с фильтром или без)
        private void RefreshGrid(string filter = "")
        {
            _context.Books.Load(); // читаем книги из базы
            // Если фильтр пустой — все книги, иначе только подходящие по названию/автору
            BooksDataGrid.ItemsSource = string.IsNullOrWhiteSpace(filter)
                ? _context.Books.Local.ToObservableCollection()
                : _context.Books.Local.Where(b => b.Title.ToLower().Contains(filter) || b.Author.ToLower().Contains(filter)).ToList();
        }

        // Выбрали книгу — её данные попадают в поля справа
        private void BooksDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BooksDataGrid.SelectedItem is not Book b) return; // ничего не выбрано — выходим
            TitleTextBox.Text = b.Title;
            AuthorTextBox.Text = b.Author; 
            GenreTextBox.Text = b.Genre;
            ReaderTextBox.Text = b.RentedBy;
        }

        // мгновенный поиск»: любое изменение текста в поле поиска сразу передаётся, а тот перерисовывает таблицу с подходящими книгами
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // поиск бзе учета регестрации
            RefreshGrid(SearchTextBox.Text.ToLower().Trim());
        }

        // Кнопка "Добавить" — создаёт новую книгу
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // название пустое или автор пустой — если да, показываем ошибку и выходим
            if (string.IsNullOrWhiteSpace(TitleTextBox.Text) || string.IsNullOrWhiteSpace(AuthorTextBox.Text))
            {
                // Показывает пользователю всплывающее окошко с текстом ошибки, кнопкой «ОК» и жёлтым значком предупреждения
                MessageBox.Show("Заполните название и автора!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Добавляем книгу и сохраняем
            _context.Books.Add(new Book { Title = TitleTextBox.Text, Author = AuthorTextBox.Text, Genre = GenreTextBox.Text });
            SaveAndReset();
        }

        // Кнопка "Удалить" — удаляет выбранную книгу
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (BooksDataGrid.SelectedItem is not Book b)
            {
                MessageBox.Show("Выберите книгу!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            _context.Books.Remove(b);
            SaveAndReset();
        }

        // Кнопка "Выдать" — книга уходит читателю
        private void RentButton_Click(object sender, RoutedEventArgs e)
        {
            // Книга выбрана, ещё не выдана, и указан читатель отмечает книгу как выданную и сохраняет
            if (BooksDataGrid.SelectedItem is Book b && !b.IsRented && !string.IsNullOrWhiteSpace(ReaderTextBox.Text))
            {
                b.IsRented = true;
                b.RentedBy = ReaderTextBox.Text;
                SaveAndRefresh("Книга успешно выдана!");
            }
            else
            {
                MessageBox.Show("Проверьте выбор книги и ФИО читателя!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Кнопка "Вернуть" — книга возвращается в библиотеку
        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            // Выбрана именно арендованная книга
            if (BooksDataGrid.SelectedItem is Book b && b.IsRented)
            {
                // Снимаем флаг выдана и стираем имя читателя
                b.IsRented = false;
                b.RentedBy = string.Empty;
                SaveAndRefresh("Книга возвращена в библиотеку!");
            }
            else
            {
                MessageBox.Show("Выберите арендованную книгу!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Сохранить в базу и очистить поля
        private void SaveAndReset()
        {
            _context.SaveChanges();
            ClearForm();
        }

        // Сохранить, обновить таблицу и показать сообщение
        private void SaveAndRefresh(string message)
        {
            _context.SaveChanges();
            BooksDataGrid.Items.Refresh();
            MessageBox.Show(message, "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Очистить все поля ввода и снять выделение
        private void ClearForm()
        {
            TitleTextBox.Text = AuthorTextBox.Text = GenreTextBox.Text = ReaderTextBox.Text = string.Empty;
            BooksDataGrid.SelectedItem = null;
        }
    }
}
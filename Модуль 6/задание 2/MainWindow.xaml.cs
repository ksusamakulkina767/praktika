using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;

namespace Модуль_6
{
    // Главное окно программы
    public partial class MainWindow : Window
    {
        // Объект для работы с базой данных
        private AppDbContext _context;

        public MainWindow()
        {
            InitializeComponent();

            // Создаём подключение к базе
            _context = new AppDbContext();

            // Если базы нет — создаём её (вместе с таблицами)
            _context.Database.EnsureCreated();

            // Загружаем задачи в таблицу на экране
            LoadData();
        }

        // Загружает задачи из базы в таблицу на экране
        private void LoadData()
        {
            // Читаем все задачи из базы
            _context.Tasks.Load();

            // Показываем их в таблице (DataGrid)
            TasksDataGrid.ItemsSource = _context.Tasks.Local.ToObservableCollection();
        }

        // Когда выбираем задачу в таблице — её данные попадают в поля ввода
        private void TasksDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TasksDataGrid.SelectedItem is TaskItem selectedTask)
            {
                TitleTextBox.Text = selectedTask.Title;
                DescriptionTextBox.Text = selectedTask.Description;
                CompletedCheckBox.IsChecked = selectedTask.IsCompleted;
            }
        }

        // Кнопка Добавить — создаёт новую задачу
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Название не должно быть пустым
            if (string.IsNullOrWhiteSpace(TitleTextBox.Text))
            {
                MessageBox.Show("Введите название задачи!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Создаём новую задачу из данных формы
            var newTask = new TaskItem
            {
                Title = TitleTextBox.Text,
                Description = DescriptionTextBox.Text,
                IsCompleted = CompletedCheckBox.IsChecked ?? false
            };

            // Добавляем в базу и сохраняем
            _context.Tasks.Add(newTask);
            _context.SaveChanges();

            // Очищаем форму
            ClearForm();
        }

        // Кнопка "Обновить" — меняет выбранную задачу
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, выбрана ли задача
            if (TasksDataGrid.SelectedItem is TaskItem selectedTask)
            {
                if (string.IsNullOrWhiteSpace(TitleTextBox.Text))
                {
                    MessageBox.Show("Название задачи не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Меняем данные задачи на новые из формы
                selectedTask.Title = TitleTextBox.Text;
                selectedTask.Description = DescriptionTextBox.Text;
                selectedTask.IsCompleted = CompletedCheckBox.IsChecked ?? false;

                // Сохраняем в базу
                _context.SaveChanges();

                // Обновляем таблицу на экране
                TasksDataGrid.Items.Refresh();

                MessageBox.Show("Задача успешно обновлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Выберите задачу в таблице для обновления!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Кнопка "Удалить" — удаляет выбранную задачу
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (TasksDataGrid.SelectedItem is TaskItem selectedTask)
            {
                // Удаляем из базы и сохраняем
                _context.Tasks.Remove(selectedTask);
                _context.SaveChanges();

                // Очищаем форму
                ClearForm();
            }
            else
            {
                MessageBox.Show("Выберите задачу в таблице для удаления!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Очищает поля ввода и снимает выделение с таблицы
        private void ClearForm()
        {
            TitleTextBox.Text = string.Empty;
            DescriptionTextBox.Text = string.Empty;
            CompletedCheckBox.IsChecked = false;
            TasksDataGrid.SelectedItem = null;
        }
    }
}
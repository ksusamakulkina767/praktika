using System.Linq;
using System.Windows;
using TaskManagerApp.Data;
using TaskManagerApp.Models;

namespace TaskManagerApp
{
    public partial class MainWindow : Window
    {
        private TaskItem selectedTask;

        public MainWindow()
        {
            InitializeComponent();

            // Создаем базу данных при запуске, если её нет
            using var db = new AppDbContext();
            db.Database.EnsureCreated();

            LoadTasks();
        }

        // Загрузка списка задач из базы в таблицу
        private void LoadTasks()
        {
            using var db = new AppDbContext();
            DgTasks.ItemsSource = db.Tasks.ToList();
        }

        // Кнопка сохранения / обновления
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtTitle.Text)) return;

            using var db = new AppDbContext();

            if (selectedTask == null)
            {
                // Добавление новой задачи
                db.Tasks.Add(new TaskItem { Title = TxtTitle.Text, Status = "В работе" });
            }
            else
            {
                // Обновление существующей
                var taskToUpdate = db.Tasks.Find(selectedTask.Id);
                if (taskToUpdate != null)
                {
                    taskToUpdate.Title = TxtTitle.Text;
                    db.Tasks.Update(taskToUpdate);
                }
            }

            db.SaveChanges();
            ClearForm();
            LoadTasks();
        }

        // Кнопка удаления
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTask != null)
            {
                using var db = new AppDbContext();
                var taskToDelete = db.Tasks.Find(selectedTask.Id);
                if (taskToDelete != null)
                {
                    db.Tasks.Remove(taskToDelete);
                    db.SaveChanges();
                }

                ClearForm();
                LoadTasks();
            }
        }

        // Выбор задачи в таблице для редактирования
        private void DgTasks_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (DgTasks.SelectedItem is TaskItem task)
            {
                selectedTask = task;
                TxtTitle.Text = task.Title;
                BtnSave.Content = "Обновить";
            }
        }

        // Очистка формы
        private void ClearForm()
        {
            selectedTask = null;
            TxtTitle.Clear();
            BtnSave.Content = "Добавить";
            if (DgTasks != null) DgTasks.UnselectAll();
        }
    }
}
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Data.Sqlite;

namespace ProjectManagementApp
{
    public partial class MainWindow : Window
    {
        // Константа со строкой подключения к локальной базе данных SQLite
        private const string Db = "Data Source=projects.db";

        // Конструктор главного окна (выполняется при запуске приложения)
        public MainWindow()
        {
            InitializeComponent(); // Инициализация визуальных элементов из XAML

            // Автоматическое создание таблиц Projects (Проекты) и Tasks (Задачи) при первом запуске
            Exec("CREATE TABLE IF NOT EXISTS Projects (ProjectID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT); CREATE TABLE IF NOT EXISTS Tasks (TaskID INTEGER PRIMARY KEY AUTOINCREMENT, ProjectID INTEGER, Title TEXT, Priority TEXT DEFAULT 'Средний', DueDate TEXT, Status TEXT DEFAULT 'К выполнению', Progress INT DEFAULT 0);");

            LoadData();      // Загрузка данных в таблицы и выпадающие списки
            CheckDeadlines(); // Проверка сроков выполнения и вывод уведомлений
        }

        // Универсальный вспомогательный метод для выполнения SQL-запросов (INSERT, UPDATE, DELETE, CREATE)
        private void Exec(string sql, Action<SqliteCommand> p = null)
        {
            using var conn = new SqliteConnection(Db); // Создаем подключение
            conn.Open();                               // Открываем соединение
            using var cmd = new SqliteCommand(sql, conn); // Создаем команду
            p?.Invoke(cmd);                            // Передаем параметры (если они есть)
            cmd.ExecuteNonQuery();                     // Выполняем запрос в БД
        }

        // Метод загрузки данных из базы в интерфейс программы
        private void LoadData()
        {
            using var conn = new SqliteConnection(Db);
            conn.Open();

            // 1. Загрузка проектов в выпадающий список (ComboBox)
            var dtProj = new DataTable();
            dtProj.Load(new SqliteCommand("SELECT ProjectID AS [Код], Name AS [Название проекта] FROM Projects;", conn).ExecuteReader());
            ProjectsComboBox.ItemsSource = dtProj.DefaultView;
            ProjectsComboBox.DisplayMemberPath = "Название проекта"; // Что видит пользователь
            ProjectsComboBox.SelectedValuePath = "Код";             // Какое ID скрыто внутри

            // 2. Загрузка задач в таблицу (DataGrid) с соединением таблиц (LEFT JOIN) для отображения названия проекта
            var dtTask = new DataTable();
            dtTask.Load(new SqliteCommand("SELECT t.TaskID AS [Код], p.Name AS [Проект], t.Title AS [Задача], t.Priority AS [Приоритет], t.DueDate AS [Срок], t.Status AS [Статус], t.Progress AS [Прогресс (%)] FROM Tasks t LEFT JOIN Projects p ON t.ProjectID = p.ProjectID;", conn).ExecuteReader());
            TasksDataGrid.ItemsSource = dtTask.DefaultView;
        }

        // Метод проверки дедлайнов (уведомления о просроченных или горящих задачах)
        private void CheckDeadlines()
        {
            using var conn = new SqliteConnection(Db);
            conn.Open();
            // Выбираем только невыполненные задачи со сроком
            using var r = new SqliteCommand("SELECT Title, DueDate FROM Tasks WHERE Status != 'Выполнено' AND DueDate IS NOT NULL;", conn).ExecuteReader();

            string msg = "";
            while (r.Read())
            {
                if (DateTime.TryParse(r["DueDate"]?.ToString(), out DateTime d))
                {
                    int days = (d.Date - DateTime.Today).Days; // Считаем разницу в днях
                    if (days < 0) msg += $"• Просрочена: «{r["Title"]}»\n";
                    else if (days <= 2) msg += $"• Дедлайн через {days} дн.: «{r["Title"]}»\n";
                }
            }
            // Если есть предупреждения — показываем всплывающее окно
            if (!string.IsNullOrEmpty(msg)) MessageBox.Show(msg, "Уведомления");
        }

        // Кнопка: Добавить новый проект
        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ProjectNameTextBox.Text)) return;
            // Выполняем вставку с параметром для защиты от SQL-инъекций
            Exec("INSERT INTO Projects (Name) VALUES (@n);", c => c.Parameters.AddWithValue("@n", ProjectNameTextBox.Text.Trim()));
            ProjectNameTextBox.Clear();
            LoadData(); // Обновляем списки
        }

        // Кнопка: Добавить новую задачу
        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TaskTitleTextBox.Text) || ProjectsComboBox.SelectedValue == null) return;

            // Считываем приоритет и дату из интерфейса
            string priority = (PriorityComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Средний";
            string date = TaskDatePicker.SelectedDate?.ToString("yyyy-MM-dd") ?? DateTime.Now.AddDays(3).ToString("yyyy-MM-dd");

            // Сохраняем задачу в базу данных
            Exec("INSERT INTO Tasks (ProjectID, Title, Priority, DueDate) VALUES (@p, @t, @pr, @d);", c => {
                c.Parameters.AddWithValue("@p", ProjectsComboBox.SelectedValue);
                c.Parameters.AddWithValue("@t", TaskTitleTextBox.Text.Trim());
                c.Parameters.AddWithValue("@pr", priority);
                c.Parameters.AddWithValue("@d", date);
            });

            TaskTitleTextBox.Clear();
            TaskDatePicker.SelectedDate = null;
            LoadData(); // Обновляем таблицу задач
        }

        // Кнопка: Удалить выбранную задачу
        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (TasksDataGrid.SelectedItem is DataRowView r)
            {
                Exec("DELETE FROM Tasks WHERE TaskID = @id;", c => c.Parameters.AddWithValue("@id", r["Код"]));
                LoadData();
            }
        }

        // Кнопка: Завершить задачу (установить прогресс 100%)
        private void CompleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (TasksDataGrid.SelectedItem is DataRowView r)
            {
                Exec("UPDATE Tasks SET Status = 'Выполнено', Progress = 100 WHERE TaskID = @id;", c => c.Parameters.AddWithValue("@id", r["Код"]));
                LoadData();
            }
        }

        // Кнопка: Сформировать отчет по проектам и количеству задач
        private void ShowReport_Click(object sender, RoutedEventArgs e)
        {
            using var conn = new SqliteConnection(Db);
            conn.Open();
            // Считаем количество задач для каждого проекта через COUNT и GROUP BY
            using var r = new SqliteCommand("SELECT p.Name, COUNT(t.TaskID) as cnt FROM Projects p LEFT JOIN Tasks t ON p.ProjectID = t.ProjectID GROUP BY p.ProjectID;", conn).ExecuteReader();

            string rep = "ОТЧЕТ:\n\n";
            while (r.Read()) rep += $"• {r["Name"]} — Задач: {r["cnt"]}\n";
            MessageBox.Show(rep, "Отчет");
        }
    }
}
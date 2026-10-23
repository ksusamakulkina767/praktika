using System;
using System.Data;
using System.Windows;
using Microsoft.Data.Sqlite;

namespace ProjectManagementApp
{
    public partial class MainWindow : Window
    {
        // Строка подключения к базе данных
        private const string ConStr = "Data Source=projects.db";

        // Этот метод запускается самым первым при открытии программы
        public MainWindow()
        {
            InitializeComponent(); // Загружает визуальные элементы интерфейса

            // Создаем таблицы в базе данных при первом запуск, если их еще нет
            ExecuteSql(@"
                CREATE TABLE IF NOT EXISTS Projects (ProjectID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Status TEXT DEFAULT 'В работе');
                CREATE TABLE IF NOT EXISTS Tasks (TaskID INTEGER PRIMARY KEY AUTOINCREMENT, ProjectID INTEGER, Title TEXT, Status TEXT DEFAULT 'К выполнению', Progress INT DEFAULT 0);");

            LoadData(); // Сразу загружаем данные в таблицы на экране
        }

        // Вспомогательный метод для выполнения запросов, которые что-то добавляют или изменяют
        private void ExecuteSql(string sql, Action<SqliteCommand> parameters = null)
        {
            using var conn = new SqliteConnection(ConStr);
            conn.Open(); // Открываем подключение к базе данных

            using var cmd = new SqliteCommand(sql, conn);
            parameters?.Invoke(cmd); // Передаем параметры в команду, если они заданы

            cmd.ExecuteNonQuery(); // Выполняем SQL-запрос, не возвращающий данные 
        }

        // Метод для загрузки данных из базы на экран 
        private void LoadData()
        {
            // Открываем подключение к базе данных
            using var conn = new SqliteConnection(ConStr);
            conn.Open();

            // Загружаем список проектов из базы данных в таблицу
            var dtProj = new DataTable();
            dtProj.Load(new SqliteCommand("SELECT ProjectID AS [Код], Name AS [Название проекта], Status AS [Статус] FROM Projects;", conn).ExecuteReader());

            // Отображаем проекты в таблице интерфейса
            // Таблица данных проекта
            ProjectsDataGrid.ItemsSource = dtProj.DefaultView;

            // Настраиваем выпадающий список проектов для выбора при создании/редактировании задачи
            ProjectsComboBox.ItemsSource = dtProj.DefaultView;
            ProjectsComboBox.DisplayMemberPath = "Название проекта"; // Что пользователь видит на экране
            ProjectsComboBox.SelectedValuePath = "Код";             // Какой скрытый ID хранится внутри выбранного пункта

            // Загружаем список задач (с помощью LEFT JOIN подтягиваем понятные названия проектов вместо их ID)
            var dtTask = new DataTable();
            dtTask.Load(new SqliteCommand("SELECT t.TaskID AS [Код], p.Name AS [Проект], t.Title AS [Задача], t.Status AS [Статус], t.Progress AS [Прогресс (%)] FROM Tasks t LEFT JOIN Projects p ON t.ProjectID = p.ProjectID;", conn).ExecuteReader());

            // Отображаем задачи в таблице интерфейса
            TasksDataGrid.ItemsSource = dtTask.DefaultView;
        }

        // Кнопка «Добавить проект»
        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            // Если поле названия пустое — ничего не делаем
            if (string.IsNullOrWhiteSpace(ProjectNameTextBox.Text)) return;

            // Добавляем проект в базу данных
            ExecuteSql("INSERT INTO Projects (Name) VALUES (@name);", c => c.Parameters.AddWithValue("@name", ProjectNameTextBox.Text.Trim()));

            ProjectNameTextBox.Clear(); // Очищаем поле ввода
            LoadData(); // Обновляем таблицы на экране
        }

        // Кнопка «Добавить задачу»
        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, что введено название задачи и выбран проект из списка
            if (string.IsNullOrWhiteSpace(TaskTitleTextBox.Text) || ProjectsComboBox.SelectedValue == null) return;

            // Вызываем метод для выполнения SQL-запроса вставки новой записи в таблицу 
            ExecuteSql("INSERT INTO Tasks (ProjectID, Title) VALUES (@pId, @title);", c => {

                // Подставляем ID выбранного проекта из выпадающего списка вместо параметра @pId
                c.Parameters.AddWithValue("@pId", ProjectsComboBox.SelectedValue);

                // Подставляем текст названия задачи из текстового поля (убрав лишние пробелы по краям) вместо параметра @title
                c.Parameters.AddWithValue("@title", TaskTitleTextBox.Text.Trim());

            }); // Закрываем передачу параметров и завершаем вызов метода

            TaskTitleTextBox.Clear(); // Очищаем поле ввода
            LoadData(); // Обновляем таблицы
        }

        // Кнопка «Завершить задачу»
        private void CompleteTask_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, выбрана ли строка в таблице задач
            if (TasksDataGrid.SelectedItem is DataRowView row)
            {
                // Меняем статус задачи на «Выполнено», а прогресс на 100%
                ExecuteSql("UPDATE Tasks SET Status = 'Выполнено', Progress = 100 WHERE TaskID = @id;", c => c.Parameters.AddWithValue("@id", row["Код"]));
                LoadData(); // Обновляем таблицы
            }
        }

        // Кнопка «Отчет по проектам»
        private void ShowReport_Click(object sender, RoutedEventArgs e)
        {
            using var conn = new SqliteConnection(ConStr);
            conn.Open();

            // Считаем количество задач для каждого проекта
            using var reader = new SqliteCommand("SELECT p.Name, p.Status, COUNT(t.TaskID) as cnt FROM Projects p LEFT JOIN Tasks t ON p.ProjectID = t.ProjectID GROUP BY p.ProjectID;", conn).ExecuteReader();

            string report = "ОТЧЕТ ПО ПРОЕКТАМ:\n\n";
            // Собираем текст отчета построчно
            while (reader.Read())
            {
                report += $"• {reader["Name"]} ({reader["Status"]}) — Задач: {reader["cnt"]}\n";
            }

            MessageBox.Show(report, "Отчет"); // Показываем отчет во всплывающем окне
        }
    }
}
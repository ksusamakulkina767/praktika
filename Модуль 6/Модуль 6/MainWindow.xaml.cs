using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace Модуль_6
{
    // Логика взаимодействия для файла MainWindow.xaml
    public partial class MainWindow : Window
    {
        // Поле для работы с базой данных 
        private AppDbContext _context;

        // Конструктор окна — выполняется при запуске программы
        public MainWindow()
        {
            InitializeComponent(); // Загружаем интерфейс из XAML

            // Создаём подключение к БД и создаём файл базы, если его нет
            _context = new AppDbContext();
            _context.Database.EnsureCreated();

            // Загружаем данные из БД в таблицу на экране
            LoadData();
        }

        // Загружает список сотрудников из БД и показывает его в таблице
        private void LoadData()
        {
            // Загружаем данные из базы в память
            _context.Employees.Load();

            // Привязываем таблицу к коллекции сотрудников.
            // ObservableCollection — сама обновляется при изменениях.
            EmployeesDataGrid.ItemsSource = _context.Employees.Local.ToObservableCollection();
        }

        // Нажатие кнопки «Добавить»
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, что поле ФИО не пустое
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Введите ФИО сотрудника!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return; // Выходим, если поле пустое
            }

            // Готовим текст зарплаты: убираем пробелы, заменяем точку/запятую на разделитель текущей культуры
            string salaryText = SalaryTextBox.Text.Trim()
                .Replace(" ", "")
                .Replace(".", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                .Replace(",", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            // Пытаемся превратить текст в число. Если не получилось — считаем 0
            if (!decimal.TryParse(salaryText, out decimal salary))
            {
                salary = 0;
            }

            // Создаём нового сотрудника из данных формы
            var employee = new Employee
            {
                FullName = NameTextBox.Text,
                Position = PositionTextBox.Text,
                Salary = salary
            };

            // Добавляем сотрудника в БД (пока только в память)
            _context.Employees.Add(employee);

            // Сохраняем изменения — запись попадает в файл базы
            _context.SaveChanges();

            // Очищаем поля ввода
            NameTextBox.Text = string.Empty;
            PositionTextBox.Text = string.Empty;
            SalaryTextBox.Text = string.Empty;
        }

        // Нажатие кнопки «Удалить выбранного»
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, выбрана ли строка, и берём её как сотрудника
            if (EmployeesDataGrid.SelectedItem is Employee selectedEmployee)
            {
                // Помечаем сотрудника на удаление
                _context.Employees.Remove(selectedEmployee);

                // Сохраняем — запись удаляется из базы
                _context.SaveChanges();
            }
            else
            {
                // Если ничего не выбрано — предупреждаем
                MessageBox.Show("Выберите сотрудника в таблице для удаления!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
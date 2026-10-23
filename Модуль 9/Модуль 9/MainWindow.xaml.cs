using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using StudentManagerWpf.Models;
using StudentManagerWpf.Services;

namespace StudentManagerWpf
{
    public partial class MainWindow : Window
    {
        // Коллекция для хранения всех объектов студентов в оперативной памяти
        private List<Student> list = new();

        // Ссылка на выбранного в данный момент студента. Если null — создается новый студент.
        private Student sel;

        // Сервис для чтения и записи данных в JSON-файл на диске
        private readonly StudentRepository repo = new();

        public MainWindow()
        {
            InitializeComponent();

            // Загружаем ранее сохраненные данные студентов из файла
            list = repo.Load();

            // Отображаем загруженный список в таблице
            Refresh();
        }

        // Обработчик нажатия на кнопку "Сохранить" или "Обновить"
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // Проверка правильности заполнения полей
            if (!int.TryParse(TxtAge.Text, out int age) || !double.TryParse(TxtGpa.Text.Replace('.', ','), out double gpa) || gpa < 1 || gpa > 10)
            {
                MessageBox.Show("Проверьте введенные данные! Возраст должен быть числом, а средний балл — находиться в диапазоне от 1 до 10.",
                                "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Если студент не выбран, добавляем нового
            if (sel == null)
            {
                int id = list.Count > 0 ? list.Max(s => s.Id) + 1 : 1;

                list.Add(new Student
                {
                    Id = id,
                    FullName = TxtFullName.Text,
                    Age = age,
                    Group = TxtGroup.Text,
                    Gpa = gpa
                });
            }
            else // Иначе обновляем существующего
            {
                sel.FullName = TxtFullName.Text;
                sel.Age = age;
                sel.Group = TxtGroup.Text;
                sel.Gpa = gpa;
            }

            // Сохраняем обновленный список в файл и очищаем форму
            repo.Save(list);
            BtnClear_Click(null, null);
        }

        // Сбрасывает состояние формы в исходное
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            sel = null;

            TxtFullName.Clear();
            TxtAge.Clear();
            TxtGroup.Clear();
            TxtGpa.Clear();

            BtnSave.Content = "Сохранить";

            if (DgStudents != null)
                DgStudents.UnselectAll();

            Refresh();
        }

        // Удаляет выбранного в таблице студента
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (sel != null)
            {
                list.Remove(sel);
                repo.Save(list);
                BtnClear_Click(null, null);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите студента в таблице для удаления!",
                                "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Заполняет поля формы данными при клике на строку в таблице
        private void DgStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgStudents.SelectedItem is Student s)
            {
                sel = s;

                TxtFullName.Text = s.FullName;
                TxtAge.Text = s.Age.ToString();
                TxtGroup.Text = s.Group;
                TxtGpa.Text = s.Gpa.ToString();

                BtnSave.Content = "Обновить";
            }
        }

        // Вызывается при изменении текста в поисковой строке
        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e) => Refresh();

        // Вызывается при переключении правила сортировки
        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e) => Refresh();

        // Метод для фильтрации, сортировки и вывода данных в таблицу DataGrid
        private void Refresh()
        {
            if (DgStudents == null) return;

            var q = list.AsEnumerable();
            string txt = TxtSearch?.Text?.ToLower() ?? "";

            // Фильтрация по ФИО или группе
            if (!string.IsNullOrEmpty(txt))
                q = q.Where(s => s.FullName.ToLower().Contains(txt) || s.Group.ToLower().Contains(txt));

            // Сортировка списка
            q = CmbSort?.SelectedIndex switch
            {
                1 => q.OrderBy(s => s.FullName),         // По имени
                2 => q.OrderBy(s => s.Age),              // По возрасту
                3 => q.OrderByDescending(s => s.Gpa),    // По среднему баллу
                _ => q.OrderBy(s => s.Id)                // По умолчанию (по ID)
            };

            DgStudents.ItemsSource = q.ToList();
        }
    }
}
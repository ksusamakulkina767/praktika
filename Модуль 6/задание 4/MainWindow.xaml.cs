using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;

namespace задание_4
{
    // Главное окно приложения — управляет финансами (доходы/расходы)
    public partial class MainWindow : Window
    {
        // Контекст базы данных. Создаётся один раз на всё окно 
        private readonly AppDbContext _context = new();

        // Конструктор окна
        public MainWindow()
        {
            InitializeComponent(); // создаёт все элементы формы (таблицу, поля, кнопки)

            _context.Database.EnsureCreated(); // если базы данных нет — создаёт её вместе с таблицами

            _context.Transactions.Load(); // читает все транзакции из базы в память

            // Привязывает таблицу к коллекции транзакций в памяти.
            // ToObservableCollection() делает так, что таблица сама обновляется при изменении коллекции.
            FinanceDataGrid.ItemsSource = _context.Transactions.Local.ToObservableCollection();
        }

        // Событие: пользователь выбрал строку в таблице.
        // Переносит данные выбранной транзакции в поля формы справа — для просмотра и редактирования.
        private void FinanceDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Если выбрана не транзакция (например, ничего не выбрано) — выходим
            if (FinanceDataGrid.SelectedItem is not TransactionItem i) return;

            // Заполняем поля формы данными выбранной транзакции
            TypeComboBox.Text = i.Type;               // тип: доход или расход
            CategoryTextBox.Text = i.Category;        // категория (например, «Продукты»)
            AmountTextBox.Text = i.Amount.ToString(); // сумма
        }

        // Кнопка «Добавить» — создаёт новую транзакцию
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем и разбираем данные из формы. Если что-то не так — метод сам покажет ошибку и вернёт false
            if (!TryParseData(out var amt, out var type)) return;

            // Создаём новую транзакцию и добавляем её в контекст
            _context.Transactions.Add(new TransactionItem
            {
                Type = type,                          // тип из выпадающего списка
                Category = CategoryTextBox.Text.Trim(), // категория без лишних пробелов по краям
                Amount = amt,                         // проверенная сумма
                Date = DateTime.Now                   // дата и время создания — сейчас
            });

            SaveAndClear(); // сохраняем в базу и очищаем форму
        }

        // Кнопка «Обновить» — изменяет выбранную транзакцию
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Если ничего не выбрано — показываем сообщение и выходим
            if (FinanceDataGrid.SelectedItem is not TransactionItem i)
            {
                MessageBox.Show("Выберите запись в таблице!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // Проверяем и разбираем данные из формы
            if (!TryParseData(out var amt, out var type)) return;

            // Обновляем свойства выбранной транзакции новыми значениями
            i.Type = type;
            i.Category = CategoryTextBox.Text.Trim();
            i.Amount = amt;

            _context.SaveChanges(); // записываем изменения в файл базы данных
            FinanceDataGrid.Items.Refresh(); // перерисовываем таблицу, чтобы изменения были видны

            MessageBox.Show("Обновлено!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Кнопка «Удалить» — удаляет выбранную транзакцию
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Если ничего не выбрано — сообщаем и выходим
            if (FinanceDataGrid.SelectedItem is not TransactionItem i)
            {
                MessageBox.Show("Выберите запись для удаления!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            _context.Transactions.Remove(i); // помечаем транзакцию на удаление в контексте
            SaveAndClear();                  // сохраняем в базу и очищаем форму
        }

        // Проверяет данные из формы и разбирает их.
        // Возвращает true, если всё корректно; иначе показывает ошибку и возвращает false.
        private bool TryParseData(out decimal amount, out string type)
        {
            amount = 0; // значение по умолчанию (обязательно для out-параметра)

            // Берём тип из выпадающего списка. Если ничего не выбрано — считаем «Расход»
            type = (TypeComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Расход";

            // Категория не должна быть пустой или из одних пробелов
            if (string.IsNullOrWhiteSpace(CategoryTextBox.Text))
            {
                MessageBox.Show("Введите категорию!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Пытаемся превратить текст суммы в число.
            // Replace('.', ',') — чтобы «10.50» тоже принималось 
            // amount <= 0 — сумма должна быть положительной.
            if (!decimal.TryParse(AmountTextBox.Text.Trim().Replace('.', ','), out amount) || amount <= 0)
            {
                MessageBox.Show("Введите корректную сумму!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true; // все проверки прошли
        }

        // Сохраняет изменения в базе данных и очищает форму ввода
        private void SaveAndClear()
        {
            _context.SaveChanges(); // записываем все изменения (добавления/удаления) в файл базы

            // Очищаем поля формы
            CategoryTextBox.Text = AmountTextBox.Text = string.Empty; // очищаем категорию и сумму
            TypeComboBox.SelectedIndex = 0;                            // выбираем первый тип (Доход/Расход)
            FinanceDataGrid.SelectedItem = null;                       // снимаем выделение в таблице
        }
    }
}
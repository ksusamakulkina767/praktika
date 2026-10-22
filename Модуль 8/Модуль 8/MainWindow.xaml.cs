using System.IO;                                            
using System.Windows;                                       
using System.Windows.Controls;                              
using System.Windows.Documents;                              
using System.Windows.Media;                                  
using Microsoft.Win32;                                       

namespace TextEditorApp                                     
{
    public partial class MainWindow : Window                
    {
        // Путь к текущему файлу (пустая строка — новый несохраненный документ)
        // Приватая строковая переменная, для хранения пути к файлу
        private string _currentFilePath = string.Empty;    

        public MainWindow()                                
        {
            InitializeComponent();                           // Загружаем визуальные элементы из XAML-разметки

            foreach (FontFamily font in Fonts.SystemFontFamilies) // Перебираем все установленные в системе шрифты
                // Добавляем название шрифта в выпадающий список
                // Хранит списк элемента
                FontFamilyComboBox.Items.Add(font.Source);   

            FontFamilyComboBox.SelectedItem = "Segoe UI";    // Устанавливаем шрифт по умолчанию в выпадающем списке
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e) // Обработчик нажатия кнопки открытия файла
        {
            var dlg = new OpenFileDialog { Filter = "RTF (*.rtf)|*.rtf|TXT (*.txt)|*.txt|Все (*.*)|*.*" }; // Настраиваем диалог открытия с фильтрами

            // Если пользователь отменил выбор файла — выходим из метода
            // Возвращает логическое значение bool
            if (dlg.ShowDialog() != true) return;         

            _currentFilePath = dlg.FileName;                 // Сохраняем путь к выбранному файлу

            // Создаем диапазон всего текста в редакторе
            // Текстовое поле, документ
            var range = new TextRange(EditorRichTextBox.Document.ContentStart, EditorRichTextBox.Document.ContentEnd); 

            // Файл для создания потока данных
            using (var fs = new FileStream(_currentFilePath, FileMode.Open)) // Открываем файловый поток для чтения
            {
                // Сравнивание текста
                if (_currentFilePath.EndsWith(".txt", System.StringComparison.OrdinalIgnoreCase)) // Проверяем, является ли файл текстовым (.txt)
                    range.Load(fs, DataFormats.Text);        // Загружаем как обычный текст
                else
                    range.Load(fs, DataFormats.Rtf);         // Загружаем как форматированный RTF
            }

            UpdateStatus();                                  // Обновляем строку состояния приложения
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) // Обработчик нажатия кнопки сохранения
        {
   
            if (string.IsNullOrEmpty(_currentFilePath)) { SaveAsButton_Click(sender, e); return; } // Если файл новый, вызываем «Сохранить как...»

            SaveFile(_currentFilePath);                      // Иначе сохраняем поверх текущего файла
        }

        private void SaveAsButton_Click(object sender, RoutedEventArgs e) // Обработчик нажатия кнопки «Сохранить как...»
        {
            var dlg = new SaveFileDialog { Filter = "RTF (*.rtf)|*.rtf|TXT (*.txt)|*.txt" }; // Настраиваем диалог сохранения файла

            if (dlg.ShowDialog() != true) return;            // Если пользователь отменил диалог — выходим

            _currentFilePath = dlg.FileName;                 // Запоминаем новый путь к файлу
            SaveFile(_currentFilePath);                      // Сохраняем файл по новому пути
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e) // Обработчик нажатия кнопки очистки редактора
        {
            EditorRichTextBox.Document.Blocks.Clear();       // Удаляем все текстовые блоки из редактора
            _currentFilePath = string.Empty;                 // Сбрасываем путь, документ снова становится новым
            UpdateStatus();                                  // Обновляем строку состояния
        }

        private void SaveFile(string path)                   // Вспомогательный метод для сохранения файла
        {
            // Текстовое поле, документ
            var range = new TextRange(EditorRichTextBox.Document.ContentStart, EditorRichTextBox.Document.ContentEnd); // Диапазон всего текста

            // Поток для передачи данных между программой
            using (var fs = new FileStream(path, FileMode.Create)) // Создаем или перезаписываем файл потоком
            {
                range.Save(fs, path.EndsWith(".txt", System.StringComparison.OrdinalIgnoreCase) ? DataFormats.Text : DataFormats.Rtf); // Сохраняем в TXT или RTF
            }

            UpdateStatus();                                  // Обновляем строку состояния
            MessageBox.Show("Файл успешно сохранен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information); // Выводим сообщение об успехе
        }

        // Сама обновляет экран
        private void ApplyStyle(DependencyProperty property, object value) // Универсальный метод применения стиля к выделению
        {
            if (EditorRichTextBox != null)                   // Проверяем, что редактор инициализирован
                // Свойство которое заменить  и что заменяем
                EditorRichTextBox.Selection.ApplyPropertyValue(property, value); // Применяем свойство к выделенному тексту
        }

        private void FontFamilyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) // Изменение шрифта
        {
            if (FontFamilyComboBox.SelectedItem != null)     // Проверяем, что шрифт выбран
                // Текстовые элементы внутри абзаца.
                ApplyStyle(Inline.FontFamilyProperty, new FontFamily(FontFamilyComboBox.SelectedItem.ToString())); // Применяем шрифт
        }

        private void FontSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) // Изменение размера шрифта
        {
            // Проверка, что именно выбрал пользователь, безопасно преобразует текст в число и гарантирует, что программа не вылетит с ошибкой
            if (FontSizeComboBox.SelectedItem is ComboBoxItem item && double.TryParse(item.Content.ToString(), out double size)) 
                ApplyStyle(Inline.FontSizeProperty, size);   // Применяем размер шрифта
        }

        private void FontColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) // Изменение цвета текста
        {
            // Код внутри сработает только тогда, когда пользователь точно ткнул в пункт меню и в этом пункте действительно заложен цвет.
            // Если не выполнится хотя бы одно из двух условий — программа просто ничего не сделает
            if (FontColorComboBox.SelectedItem is ComboBoxItem item && item.Tag != null) 
            {
                var brush = new BrushConverter().ConvertFromString(item.Tag.ToString()) as Brush; // Конвертируем тег в кисть
                if (brush != null) ApplyStyle(Inline.ForegroundProperty, brush); // Применяем цвет текста
            }
        }

        private void EditorRichTextBox_TextChanged(object sender, TextChangedEventArgs e) // Событие изменения текста в редакторе
        {
            string text = new TextRange(EditorRichTextBox.Document.ContentStart, EditorRichTextBox.Document.ContentEnd).Text.Trim(); // Извлекаем весь текст

            int chars = text.Length;                         // Подсчитываем общее количество символов

            // Проверка, не пустой ли текст.
            // Если пустой — выдает 0.А если нет — разрезает текст по пробелам и переносам строк на отдельные слова и считает их общее количество, запихивая готовое число в переменную
            int words = string.IsNullOrWhiteSpace(text) ? 0 : text.Split(new[] { ' ', '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries).Length; 

            if (StatsTextBlock != null)                      // Проверяем существование элемента статистики
                StatsTextBlock.Text = $"Слов: {words} | Символов: {chars}"; // Выводим статистику в строку состояния
        }

        private void UpdateStatus()                          // Метод обновления строки состояния с путем к файлу
        {
            StatusTextBlock.Text = string.IsNullOrEmpty(_currentFilePath) ? " Новый документ" : $" {_currentFilePath}"; // Показываем статус или путь
        }
    }
}
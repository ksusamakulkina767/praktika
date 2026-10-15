using System; 
using System.IO; 
using System.Windows.Forms; 

namespace Задание2 
{
    public partial class Form1 : Form 
    {
        // Переменная для хранения пути к файлу
        // объявление пустой строковой переменной
        string filePath = "";
        public Form1()
        {
            InitializeComponent(); // Создание элементов формы
        }

        // Метод открытия файла
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Создание диалогового окна для выбора файла
            OpenFileDialog open = new OpenFileDialog();

            // Установка фильтра для текстовых файлов
            open.Filter = "Текстовые файлы (*.txt)|*.txt";

            // Проверка, выбрал ли пользователь файл и нажал ли «ОК»
            if (open.ShowDialog() == DialogResult.OK)
            {
                // Сохранение пути к выбранному файлу
                filePath = open.FileName;

                // Чтение текста из файла и отображение в поле
                richTextBox1.Text = File.ReadAllText(filePath);
            }
        }

        // Метод сохранения файла
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Проверка, выбран ли ранее файл для сохранения
            if (filePath == "")
            {
                // Создание диалогового окна для сохранения файла
                SaveFileDialog save = new SaveFileDialog();

                // Установка фильтра для текстовых файлов
                save.Filter = "Текстовые файлы (*.txt)|*.txt";

                // Проверка, подтвердил ли пользователь сохранение
                if (save.ShowDialog() != DialogResult.OK)
                    return; // Завершение метода, если сохранение отменено

                // Сохранение выбранного пути к файлу
                filePath = save.FileName;
            }

            // Запись текста из поля в файл
            File.WriteAllText(filePath, richTextBox1.Text);

            // Вывод сообщения об успешном сохранении
            MessageBox.Show("Файл сохранён!");
        }

        // Метод выхода из программы
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        // Метод, который вызывается при загрузке формы
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
    }
}

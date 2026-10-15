using System;
using System.Windows.Forms;

namespace Задание2
{
    public partial class Form1 : Form
    {
        // Создаем объект менеджера, который отвечает за чтение, запись и хранение пути к файлу
        private FileManager fileManager = new FileManager();

        public Form1()
        {
            InitializeComponent();
        }

        // Открытие существующего файла
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Настраиваем диалоговое окно для выбора текстового файла
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Текстовые файлы (*.txt)|*.txt";

            // Если пользователь выбрал файл и нажал «Открыть»
            if (open.ShowDialog() == DialogResult.OK)
            {
                // Читаем текст через менеджер и выводим его на экран в richTextBox1
                richTextBox1.Text = fileManager.OpenFile(open.FileName);
            }
        }

        // Сохранение файла
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Если путь к файлу еще не задан (файл новый), спрашиваем, куда его сохранить
            if (string.IsNullOrEmpty(fileManager.GetFilePath()))
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Текстовые файлы (*.txt)|*.txt";

                // Если пользователь передумал сохранять и нажал «Отмена» — выходим
                if (save.ShowDialog() != DialogResult.OK)
                    return;

                // Запоминаем путь, который выбрал пользователь
                fileManager.SetFilePath(save.FileName);
            }

            // Записываем текст из текстового поля в файл через менеджер
            fileManager.SaveFile(richTextBox1.Text);

            // Сообщение об успешном сохранении
            MessageBox.Show("Файл сохранён!");
        }

        // Выход из программы
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Событие загрузки формы (остается пустым)
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
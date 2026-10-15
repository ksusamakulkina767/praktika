using System; 
using System.Windows.Forms; 

namespace Задание_3 
{
    public partial class Form1 : Form 
    {

        public Form1()
        {
            InitializeComponent(); // Создание элементов формы
        }

        // Метод, который выполняется при загрузке формы
        // метод вызывается только системой (через событие клика на кнопке)
        private void Form1_Load(object? sender, EventArgs e)
        {
            lstTasks.Items.Clear(); // Очистка списка задач при запуске программы
        }

        // Метод добавления новой задачи
        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            // Получение текста из поля ввода и удаление пробелов по краям
            string taskText = txtTaskInput.Text.Trim();

            // Проверка, пустое ли поле ввода
            if (string.IsNullOrEmpty(taskText))
            {
                // Вывод предупреждения, если текст не введён
                MessageBox.Show(
                    "Введите текст задачи!",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return; 
            }

            // Добавление задачи в список с выключенным флажком
            lstTasks.Items.Add(taskText, false);

            txtTaskInput.Clear(); // Очистка поля ввода после добавления задачи
            txtTaskInput.Focus(); // Перемещение курсора в поле ввода
        }

        // Метод удаления выбранных задач
        // метод вызывается только системой (через событие клика на кнопке)
        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            // Проверка, выбрана ли хотя бы одна задача
            if (lstTasks.SelectedItems.Count == 0)
            {
                // Вывод предупреждения, если задача не выбрана
                MessageBox.Show(
                    "Выберите задачу для удаления!",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return; 
            }

            // Перебор выбранных задач в обратном порядке
            for (int i = lstTasks.SelectedIndices.Count - 1; i >= 0; i--)
            {
                // Получение индекса выбранной задачи
                int index = lstTasks.SelectedIndices[i];

                // Удаление задачи из списка по индексу
                lstTasks.Items.RemoveAt(index);
            }
        }
    }
}

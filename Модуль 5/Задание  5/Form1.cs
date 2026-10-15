using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Задание_3
{
    public partial class Form1 : Form
    {
        // Создаем объект менеджера для управления задачами
        private TaskManager taskManager = new TaskManager();

        public Form1()
        {
            InitializeComponent();
        }

        // Событие при загрузке формы
        private void Form1_Load(object? sender, EventArgs e)
        {
            lstTasks.Items.Clear(); // Очищаем список на экране при запуске
        }

        // Кнопка добавления новой задачи
        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            string taskText = txtTaskInput.Text;

            // Пытаемся добавить задачу через менеджер
            if (!taskManager.AddTask(taskText))
            {
                // Если текст пустой, показываем предупреждение пользователю
                MessageBox.Show(
                    "Введите текст задачи!",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Добавляем задачу в визуальный список на форме с галочкой (false — не выполнена)
            lstTasks.Items.Add(taskText.Trim(), false);

            txtTaskInput.Clear(); // Очищаем поле ввода
            txtTaskInput.Focus(); // Возвращаем фокус обратно в поле ввода
        }

        // Кнопка удаления выбранных задач
        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            // Проверяем, выбрал ли пользователь хоть что-то в списке
            if (lstTasks.SelectedItems.Count == 0)
            {
                MessageBox.Show(
                    "Выберите задачу для удаления!",
                    "Внимание",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Собираем индексы выбранных элементов в список
            List<int> selectedIndices = new List<int>();
            for (int i = 0; i < lstTasks.SelectedIndices.Count; i++)
            {
                selectedIndices.Add(lstTasks.SelectedIndices[i]);
            }

            // Удаляем задачи из логического менеджера
            taskManager.DeleteTasks(selectedIndices);

            // Удаляем задачи с экрана в обратном порядке, чтобы индексы не смещались при удалении
            for (int i = lstTasks.SelectedIndices.Count - 1; i >= 0; i--)
            {
                int index = lstTasks.SelectedIndices[i];
                lstTasks.Items.RemoveAt(index);
            }
        }
    }
}
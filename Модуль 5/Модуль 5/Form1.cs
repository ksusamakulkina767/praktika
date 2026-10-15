using System;
using System.Drawing;
using System.Windows.Forms;

namespace Модуль_5
{
    public partial class Form1 : Form
    {
        // Создаем объект, который управляет всем процессом рисования и состоянием холста
        private DrawingManager drawingManager = new DrawingManager();

        public Form1()
        {
            InitializeComponent();
        }

        // Событие срабатывает при загрузке формы
        private void Form1_Load(object sender, EventArgs e)
        {
            InitCanvas(); // Создаем начальный холст при запуске
        }

        // Метод для создания и подготовки холста
        private void InitCanvas()
        {
            // Передаем текущие размеры экрана в менеджер рисования
            drawingManager.InitCanvas(pictureBox1.Width, pictureBox1.Height);

            // Выводим созданное изображение на экран (в pictureBox)
            pictureBox1.Image = drawingManager.GetBitmap();
        }

        // Кнопки выбора инструментов

        private void btnLine_Click(object sender, EventArgs e)
        {
            drawingManager.SetTool(Tool.Line); // Выбираем инструмент «Линия»
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            drawingManager.SetTool(Tool.Circle); // Выбираем инструмент «Круг»
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            drawingManager.SetTool(Tool.Square); // Выбираем инструмент «Квадрат»
        }

        // Кнопка очистки

        private void btnClear_Click(object sender, EventArgs e)
        {
            InitCanvas();          // Заново создаем пустой белый холст
            pictureBox1.Refresh(); // Обновляем экран
        }

        // Рисование по клику мыши

        private void OnCanvasClick(object sender, EventArgs e)
        {
            // Узнаем, куда именно кликнул пользователь (координаты мыши на холсте)
            Point p = pictureBox1.PointToClient(Cursor.Position);

            // Передаем координаты менеджеру, чтобы он нарисовал нужную фигуру
            drawingManager.DrawShape(p);

            // Принудительно обновляем экран, чтобы фигура сразу отобразилась
            pictureBox1.Refresh();
        }

        // Переопределяем метод закрытия формы, чтобы освободить память компьютера от картинки
        // дополнить поведение родителя Form при закрытии
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            pictureBox1.Image = null;   // Убираем картинку с элемента
            drawingManager.Dispose();   // Удаляем холст из памяти
            base.OnFormClosed(e);
        }

        // Служебный метод панели (остается пустым)
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
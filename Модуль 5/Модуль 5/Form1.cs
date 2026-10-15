using System; 
using System.Drawing; 
using System.Windows.Forms; 

namespace Модуль_5 
{
    public partial class Form1 : Form
    {
        // Перечисление инструментов для рисования
        enum Tool
        {
            Line,   // Линия
            Circle, // Круг
            Square  // Квадрат
        }

        // Переменная для хранения выбранного инструмента
        Tool currentTool = Tool.Circle;

        // Переменная для хранения изображения холста
        // Растровое изображение
        Bitmap bitmap;
        public Form1()
        {
            InitializeComponent(); // Создание кнопок, холста и других элементов формы
        }

        // Метод запускается при открытии формы
        private void Form1_Load(object sender, EventArgs e)
        {
            InitCanvas(); // Создание белого холста
        }

        // Метод настройки холста для рисования
        private void InitCanvas()
        {
            // Проверка размеров холста
            // Если у pictureBox1 ширина или высота меньше или равна нулю, выходим из метода
            if (pictureBox1.Width <= 0 || pictureBox1.Height <= 0)
                return;

            // Проверка наличия предыдущего изображения
            if (bitmap != null)
                bitmap.Dispose(); // Освобождение памяти от старого изображения

            // Создание нового изображения по размерам холста
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            // Создание объекта для рисования на изображении
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White); // Заполнение холста белым цветом
            }

            // Установка изображения на холст
            pictureBox1.Image = bitmap;
        }

        // Метод выбора инструмента «Линия»
        // метод вызывается только системой (через событие клика на кнопке)
        private void btnLine_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Line; // Установка инструмента «Линия»
        }

        // Метод выбора инструмента «Круг»
        private void btnCircle_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Circle; // Установка инструмента «Круг»
        }

        // Метод выбора инструмента «Квадрат»
        private void btnSquare_Click(object sender, EventArgs e)
        {
            currentTool = Tool.Square; // Установка инструмента «Квадрат»
        }

        // Метод очистки холста
        private void btnClear_Click(object sender, EventArgs e)
        {
            InitCanvas(); // Создание нового чистого холста
        }

        // Метод рисования фигуры при нажатии на холст
        private void OnCanvasClick(object sender, EventArgs e)
        {
            // Проверка наличия изображения
            if (bitmap == null)
                return;

            // Получение координат курсора относительно холста
            // переводит позицию курсора с экрана в координаты внутри pictureBox1
            Point p = pictureBox1.PointToClient(Cursor.Position);

            // Создание инструмента рисования синего цвета толщиной 3 пикселя
            // 	перо синего цвета, толщина 3 пикселя
            using (Graphics g = Graphics.FromImage(bitmap))
            using (Pen pen = new Pen(Color.Blue, 3))
            {
                // Вычисление координат верхнего левого угла фигуры
                // сдвигает координаты курсора на радиус (30) влево и вверх, чтобы получить левый верхний угол фигуры
                int x = p.X - 30;
                int y = p.Y - 30;

                // Проверка выбранного инструмента
                if (currentTool == Tool.Line)
                {
                    // Рисование горизонтальной линии длиной 60 пикселей
                    g.DrawLine(pen, p.X - 30, p.Y, p.X + 30, p.Y);
                }
                // проверка «если выбран инструмент Круг, то выполни этот блок
                else if (currentTool == Tool.Circle)
                {
                    // Рисование круга размером 60 на 60 пикселей
                    g.DrawEllipse(pen, x, y, 60, 60);
                }
              else if (currentTool == Tool.Square)  
                {
                    // Рисование квадрата размером 60 на 60 пикселей
                    g.DrawRectangle(pen, x, y, 60, 60);
                }
            }

            // Обновление изображения для отображения нарисованной фигуры
            pictureBox1.Refresh();
        }

        // Метод закрытия формы и освобождения ресурсов
        // protected потому что родитель так объявил, а при override менять нельзя
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            pictureBox1.Image = null; // Удаление ссылки на изображение из холста

            // Проверка наличия изображения перед освобождением памяти
            if (bitmap != null)
                bitmap.Dispose(); // Освобождение памяти, занятой изображением
            base.OnFormClosed(e);
        }
        // обработчик события, срабатывает при каждой перерисовке панели
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

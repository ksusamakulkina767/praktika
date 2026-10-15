using System;
using System.Drawing;

namespace Модуль_5
{
    /// <summary>
    /// Перечисление доступных инструментов для рисования.
    /// Вынесено в публичный доступ, чтобы форма могла с ним взаимодействовать.
    /// </summary>
    public enum Tool
    {
        Line,   // Линия
        Circle, // Круг
        Square  // Квадрат
    }

    /// <summary>
    /// Класс, отвечающий за логику рисования, управление холстом (Bitmap) и выбор инструментов.
    /// Полностью отделен от графического интерфейса Windows Forms.
    /// </summary>
    public class DrawingManager : IDisposable
    {
        // Растровое изображение (холст), на котором происходит рисование
        private Bitmap bitmap;

        // Текущий выбранный инструмент (по умолчанию Круг)
        private Tool currentTool = Tool.Circle;

        /// <summary>
        /// Установка выбранного инструмента для рисования.
        /// </summary>
        public void SetTool(Tool tool)
        {
            currentTool = tool;
        }

        /// <summary>
        /// Инициализация или сброс (очистка) холста.
        /// </summary>
        /// <param name="width">Ширина холста</param>
        /// <param name="height">Высота холста</param>
        public void InitCanvas(int width, int height)
        {
            // Проверка корректности размеров
            if (width <= 0 || height <= 0)
                return;

            // Если старое изображение существовало, освобождаем память
            if (bitmap != null)
                bitmap.Dispose();

            // Создаем новый Bitmap по размерам элемента pictureBox
            bitmap = new Bitmap(width, height);

            // Очищаем холст, заливая его белым цветом
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
            }
        }

        /// <summary>
        /// Метод рисования выбранной фигуры по заданным координатам.
        /// </summary>
        /// <param name="p">Точка клика мыши</param>
        public void DrawShape(Point p)
        {
            if (bitmap == null)
                return;

            // Создаем объект Graphics для рисования на bitmap и перо синего цвета толщиной 3 пикселя
            using (Graphics g = Graphics.FromImage(bitmap))
            using (Pen pen = new Pen(Color.Blue, 3))
            {
                // Вычисление верхнего левого угла для центрирования фигуры (сдвиг на 30 пикселей)
                int x = p.X - 30;
                int y = p.Y - 30;

                // Рисование в зависимости от выбранного инструмента
                if (currentTool == Tool.Line)
                {
                    // Рисование горизонтальной линии длиной 60 пикселей
                    g.DrawLine(pen, p.X - 30, p.Y, p.X + 30, p.Y);
                }
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
        }

        /// <summary>
        /// Возвращает текущее изображение (холст).
        /// </summary>
        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        /// <summary>
        /// Метод освобождения ресурсов (реализация интерфейса IDisposable).
        /// </summary>
        public void Dispose()
        {
            if (bitmap != null)
            {
                bitmap.Dispose();
                bitmap = null;
            }
        }
    }
}
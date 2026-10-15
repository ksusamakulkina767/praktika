using System;
using System.Drawing;
using System.Windows.Forms;

namespace Задание_4
{
    public partial class Form1 : Form
    {
        // Переменная для хранения исходного, неизмененного изображения
        private Image? originalImage = null;

        // Текущий коэффициент масштабирования (1.0 = 100% исходного размера)
        private double zoomFactor = 1.0;

        public Form1()
        {
            InitializeComponent();
        }

        // Обработчик нажатия кнопки "Открыть файл"
        public void BtnOpen_Click(object? sender, EventArgs e)
        {
            // Используем стандартный диалог выбора файла
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // Ограничиваем список доступных расширений графическими форматами
                ofd.Filter = "Изображения (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Загружаем выбранное изображение в память
                    originalImage = Image.FromFile(ofd.FileName);

                    // Выводим картинку в элемент PictureBox
                    picImage.Image = originalImage;

                    // Сбрасываем масштаб при открытии новой картинки
                    zoomFactor = 1.0;
                }
            }
        }

        // Обработчик кнопки увеличения масштаба + 
        public void BtnZoomIn_Click(object? sender, EventArgs e)
        {
            // если исходного изображения нет, метод просто выходит, не выполняя дальнейший код
            if (originalImage == null) return;

            zoomFactor += 0.2; // Увеличиваем масштаб на 20%
            ApplyZoom();       // Применяем изменения
        }

        // Обработчик кнопки уменьшения масштаба -
        public void BtnZoomOut_Click(object? sender, EventArgs e)
        {
            if (originalImage == null) return;

            // Защита от слишком сильного уменьшения (не меньше 30%)
            if (zoomFactor > 0.3)
                zoomFactor -= 0.2; // Уменьшаем масштаб на 20%

            ApplyZoom();       // Применяем изменения
        }

        // Вспомогательный метод для пересчета размера и отрисовки масштабированной картинки 
        private void ApplyZoom()
        {
            if (originalImage == null) return;

            // вычисление новой ширины изображения после масштабирования
            // то же, что и с шириной, только для высоты
            int newWidth = (int)(originalImage.Width * zoomFactor);
            int newHeight = (int)(originalImage.Height * zoomFactor);

            // Изменяем размер PictureBox (благодаря панели со скроллами появятся полосы прокрутки)
            picImage.Size = new Size(newWidth, newHeight);

            // Создаем новый объект Bitmap с измененными размерами на основе оригинала
            Bitmap zoomedBmp = new Bitmap(originalImage, newWidth, newHeight);

            // Устанавливаем обновленное изображение в PictureBox
            picImage.Image = zoomedBmp;
        }

        // Служебный метод загрузки формы (оставлен пустым)
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
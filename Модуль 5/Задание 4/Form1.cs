using System;
using System.Drawing;
using System.Windows.Forms;

namespace Задание_4
{
    public partial class Form1 : Form
    {
        // Создаем объект менеджера для работы с изображением и масштабом
        private ImageZoomManager imageManager = new ImageZoomManager();

        public Form1()
        {
            InitializeComponent();
        }

        // Кнопка открытия файла изображения
        public void BtnOpen_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // Ограничиваем выбор только популярными графическими форматами
                ofd.Filter = "Изображения (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Передаем путь к файлу менеджеру
                    imageManager.LoadImage(ofd.FileName);

                    // Применяем масштаб (отображаем картинку 100%)
                    ApplyZoom();
                }
            }
        }

        // Кнопка увеличения масштаба (+)
        public void BtnZoomIn_Click(object? sender, EventArgs e)
        {
            if (!imageManager.HasImage()) return;

            imageManager.ZoomIn(); // Увеличиваем зум в менеджере
            ApplyZoom();           // Обновляем картинку на экране
        }

        // Кнопка уменьшения масштаба (-)
        public void BtnZoomOut_Click(object? sender, EventArgs e)
        {
            if (!imageManager.HasImage()) return;

            imageManager.ZoomOut(); // Уменьшаем зум в менеджере
            ApplyZoom();            // Обновляем картинку на экране
        }

        // Вспомогательный метод для обновления картинки и размера на экране
        private void ApplyZoom()
        {
            if (!imageManager.HasImage()) return;

            // Получаем готовую картинку нужного размера из менеджера
            Bitmap? zoomedBmp = imageManager.GetZoomedBitmap(out int newWidth, out int newHeight);

            if (zoomedBmp != null)
            {
                // Меняем размер PictureBox (благодаря панели со скроллами появятся полосы прокрутки)
                picImage.Size = new Size(newWidth, newHeight);

                // Выводим изображение на экран
                picImage.Image = zoomedBmp;
            }
        }

        // Событие загрузки формы (остается пустым)
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
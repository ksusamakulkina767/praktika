using System.Drawing;

namespace Задание_4
{
    public class ImageZoomManager
    {
        // Исходное, неизмененное изображение
        private Image? originalImage = null;

        // Текущий коэффициент масштабирования (1.0 = 100%)
        private double zoomFactor = 1.0;

        // Загружает новое изображение и сбрасывает масштаб
        public void LoadImage(string filePath)
        {
            if (originalImage != null)
            {
                originalImage.Dispose();
            }

            originalImage = Image.FromFile(filePath);
            zoomFactor = 1.0; // При открытии новой картинки масштаб сбрасывается
        }

        // Проверка, загружена ли картинка
        public bool HasImage()
        {
            return originalImage != null;
        }

        // Увеличивает масштаб на 20%
        public void ZoomIn()
        {
            if (originalImage == null) return;
            zoomFactor += 0.2;
        }

        // Уменьшает масштаб на 20% (но не меньше 30%)
        public void ZoomOut()
        {
            if (originalImage == null) return;

            if (zoomFactor > 0.3)
            {
                zoomFactor -= 0.2;
            }
        }

        // Создает и возвращает отмасштабированную картинку
        public Bitmap? GetZoomedBitmap(out int newWidth, out int newHeight)
        {
            newWidth = 0;
            newHeight = 0;

            if (originalImage == null) return null;

            // Считаем новые размеры с учетом текущего зума
            newWidth = (int)(originalImage.Width * zoomFactor);
            newHeight = (int)(originalImage.Height * zoomFactor);

            // Создаем новый Bitmap нужного размера на основе оригинала
            return new Bitmap(originalImage, newWidth, newHeight);
        }

        // Получение текущего масштаба (если нужно для отладки или отображения)
        public double GetZoomFactor()
        {
            return zoomFactor;
        }
    }
}
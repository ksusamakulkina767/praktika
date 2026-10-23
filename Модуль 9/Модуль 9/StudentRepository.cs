using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using StudentManagerWpf.Models;

namespace StudentManagerWpf.Services
{
    // Класс-репозиторий для сохранения и загрузки данных студентов из JSON-файла
    public class StudentRepository
    {
        // Имя файла, в котором будут храниться данные
        private const string FilePath = "students.json";

        // Загрузка списка студентов из файла
        public List<Student> Load()
        {
            try
            {
                // Проверяем, существует ли файл на диске
                if (File.Exists(FilePath))
                {
                    // Читаем весь текст из файла
                    string json = File.ReadAllText(FilePath);

                    // Десериализуем JSON-строку в список студентов (если файл пустой, возвращаем новый пустой список)
                    return JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
                }
            }
            catch (Exception ex)
            {
                // Выбрасываем понятное исключение при ошибке чтения
                throw new Exception($"Ошибка чтения файла: {ex.Message}");
            }

            // Если файл еще не создан, возвращаем пустой список
            return new List<Student>();
        }

        // Сохранение списка студентов в файл
        public void Save(List<Student> students)
        {
            try
            {
                // Настройка сериализации: включаем красивое форматирование с отступами (WriteIndented)
                var options = new JsonSerializerOptions { WriteIndented = true };

                // Превращаем список студентов в JSON-строку
                string json = JsonSerializer.Serialize(students, options);

                // Записываем полученный текст в файл
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                // Выбрасываем понятное исключение при ошибке записи
                throw new Exception($"Ошибка сохранения файла: {ex.Message}");
            }
        }
    }
}
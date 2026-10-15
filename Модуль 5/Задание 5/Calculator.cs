using System;

namespace Задание_5
{
    /// Класс, реализующий логику работы калькулятора (хранение состояния и вычисления).
    public class Calculator
    {
        // Текущее значение на дисплее в виде строки
        private string currentInput = "0";

        // Сохраненное первое число для последующей операции
        private double a = 0;

        // Выбранная математическая операция ("+", "-", "*", "/")
        private string operation = "";

        // Флаг, указывающий, что только что было нажато равно или выбрана операция 
        // (чтобы при вводе следующей цифры поле очищалось)
        private bool isNewEntry = false;

        /// Возвращает текущий текст для отображения на экране калькулятора.
        public string GetDisplayText()
        {
            return currentInput;
        }

        /// Ввод цифры (от 0 до 9).
        public void AddDigit(string digit)
        {
            if (isNewEntry)
            {
                currentInput = digit; // Если это новый ввод, заменяем текст
                isNewEntry = false;
            }
            else if (currentInput == "0")
            {
                currentInput = digit; // Если на экране только дефолтный "0", заменяем его
            }
            else
            {
                currentInput += digit; // Иначе дописываем цифру в конец строки
            }
        }

        // Ввод десятичной запятой (для дробных чисел).
        public void AddComma()
        {
            if (isNewEntry)
            {
                currentInput = "0,";
                isNewEntry = false;
            }
            else if (!currentInput.Contains(","))
            {
                currentInput += ","; // Добавляем запятую, только если её еще нет в числе
            }
        }

        // Установка математической операции (+, -, *, /).
        public void SetOperation(string op)
        {
            // Если в строке введено число, парсим его и сохраняем в переменную 'a'
            if (double.TryParse(currentInput, out double val))
            {
                a = val;
            }
            operation = op;       // Запоминаем выбранную операцию
            isNewEntry = true;    // Включаем флаг для ввода следующего числа
        }

        // Вычисление конечного результата (=).
        public bool Calculate(out string resultMessage)
        {
            resultMessage = "";

            // Считываем второе число (b) из текущего ввода
            if (!double.TryParse(currentInput, out double b))
            {
                b = 0;
            }

            // Выполняем расчет в зависимости от выбранного оператора
            if (operation == "+")
            {
                a += b;
            }
            else if (operation == "-")
            {
                a -= b;
            }
            else if (operation == "*")
            {
                a *= b;
            }
            else if (operation == "/")
            {
                // Обработка попытки деления на ноль
                if (b == 0)
                {
                    resultMessage = "На ноль делить нельзя!";
                    return false;
                }
                a /= b;
            }

            // Превращаем результат обратно в строку для отображения
            // преобразование в строку
            currentInput = a.ToString();
            isNewEntry = true;
            operation = ""; // Сбрасываем операцию после завершения расчета
            return true;
        }
        /// Полная очистка калькулятора (кнопка "С").
        public void Clear()
        {
            currentInput = "0";   // Возвращаем нуль на дисплей
            a = 0;                // Обнуляем первое число
            operation = "";       // Сбрасываем операцию
            isNewEntry = false;   // Сбрасываем флаг ввода
        }
    }
}
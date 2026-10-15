using System;                   
using System.Windows.Forms;     

namespace Задание_5            
{
    public partial class Form1 : Form
    {
        // Поле логики калькулятора. private — используется только внутри формы
        private Calculator calc = new Calculator();

        // Конструктор формы. public — вызывается средой при создании окна.
        public Form1()
        {
            InitializeComponent();   
            UpdateDisplay();         // Показываем начальное состояние калькулятора ("0")
        }

        // Вспомогательный метод: переносит текст из логики в поле ввода на экране.
        private void UpdateDisplay()
        {
            textBox1.Text = calc.GetDisplayText();   // Забираем у калькулятора актуальную строку и показываем
        }

        // Блок ввода цифр от 0 до 9 
        // Логика одинакова: передать цифру в Calculator, затем обновить экран.
        // пользователь кликнет по кнопке, передай в логику калькулятора цифру "0" и обнови экран, чтобы пользователь увидел изменение

        private void btn0_Click(object sender, EventArgs e) { calc.AddDigit("0"); UpdateDisplay(); }
        private void btn1_Click(object sender, EventArgs e) { calc.AddDigit("1"); UpdateDisplay(); }
        private void btn2_Click(object sender, EventArgs e) { calc.AddDigit("2"); UpdateDisplay(); }
        private void btn3_Click(object sender, EventArgs e) { calc.AddDigit("3"); UpdateDisplay(); }
        private void btn4_Click(object sender, EventArgs e) { calc.AddDigit("4"); UpdateDisplay(); }
        private void btn5_Click(object sender, EventArgs e) { calc.AddDigit("5"); UpdateDisplay(); }
        private void btn6_Click(object sender, EventArgs e) { calc.AddDigit("6"); UpdateDisplay(); }
        private void btn7_Click(object sender, EventArgs e) { calc.AddDigit("7"); UpdateDisplay(); }
        private void btn8_Click(object sender, EventArgs e) { calc.AddDigit("8"); UpdateDisplay(); }
        private void btn9_Click(object sender, EventArgs e) { calc.AddDigit("9"); UpdateDisplay(); }

        // Блок выбора математической операции 
        // При нажатии на +, -, *, / логика запоминает первое число и операцию.

        private void btnAdd_Click(object sender, EventArgs e) { calc.SetOperation("+"); }
        private void btnMin_Click(object sender, EventArgs e) { calc.SetOperation("-"); }
        private void btnMul_Click(object sender, EventArgs e) { calc.SetOperation("*"); }
        private void btnDiv_Click(object sender, EventArgs e) { calc.SetOperation("/"); }

        // Вычисление результата (=)
        private void btnEquals_Click(object sender, EventArgs e)
        {
            // Calculate возвращает true при успехе.
            // Если false — в errorMsg лежит текст ошибки (например, деление на ноль).
            // out string errorMsg — параметр, через который метод вернёт сообщение наружу.
            if (!calc.Calculate(out string errorMsg))
            {
                MessageBox.Show(errorMsg);   // Показываем окно с ошибкой пользователю
            }
            UpdateDisplay();                 // В любом случае обновляем экран (результат или ошибка)
        }

        // Кнопка полной очистки (C) 
        private void btnClear_Click(object sender, EventArgs e)
        {
            calc.Clear();          // Сбрасываем состояние калькулятора в исходное
            UpdateDisplay();       // И сразу отображаем "0" на экране
        }

        // Обработчик события Load формы. Подключён дизайнером, но пустой — логика
        // инициализации вынесена в конструктор. Можно удалить без последствий.
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
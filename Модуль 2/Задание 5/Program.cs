using System;
class TemperatureSensor
{
    public event Action<double> TemperatureChanged;
    // Измерение температуры
    public void Measure(double t) // метод измерения температуры
    {
        Console.WriteLine("Температура: " + t);
        // Запуск события
        TemperatureChanged?.Invoke(t); // передает новое значение температуры всем подключенным методам
    }
}
class Thermostat
{
    public void Subscribe(TemperatureSensor sensor) // подключение к датчику
    {
        sensor.TemperatureChanged += Check;
    }
    void Check(double t) // проверка температуры
    {
        // Если температура меньше 20
        if (t < 20)
            Console.WriteLine("Отопление включено");
        else
            Console.WriteLine("Отопление выключено");
    }
}
class Program
{
    static void Main()
    {
        // Создание датчика
        TemperatureSensor sensor = new TemperatureSensor();
        // Создание термостата
        Thermostat thermostat = new Thermostat();
        // Подключение термостата
        thermostat.Subscribe(sensor);
        // Цикл ввода температуры
        while (true)
        {
            Console.Write("Температура: ");
            string s = Console.ReadLine();

            // если пользователь ничего не ввел программа останавливается
            if (s == "")
                break;

            // Проверка введённого числа
            if (double.TryParse(s, out double t))
                sensor.Measure(t);
            else
                Console.WriteLine("Ошибка!");
        }
    }
}
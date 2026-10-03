using System;
class Notification
{
    // Событие сообщения
    public event Action<string> Message;

    // Событие звонка
    public event Action<string> Call;

    // Событие электронной почты
    public event Action<string> Email;

    // Метод отправки сообщения
    public void SendMessage(string text)
    {
        // Вызов события сообщения
        Message?.Invoke(text);
    }

    // Метод отправки звонка
    public void SendCall(string number)
    {
        // Вызов события звонка
        Call?.Invoke(number);
    }

    // Метод отправки электронной почты
    public void SendEmail(string text)
    {
        // Вызов события электронной почты
        Email?.Invoke(text);
    }
}
class Program
{
    // Обработчик события сообщения
    static void MessageHandler(string text)
    {
        Console.WriteLine("Сообщение: " + text);
    }

    // Обработчик события звонка
    static void CallHandler(string number)
    {
        Console.WriteLine("Звонок от: " + number);
    }

    // Обработчик события электронной почты
    static void EmailHandler(string text)
    {
        Console.WriteLine("Письмо: " + text);
    }

    static void Main()
    {
        // Создание объекта уведомления
        Notification notification = new Notification();

        // Регистрация обработчика сообщения
        notification.Message += MessageHandler;

        // Регистрация обработчика звонка
        notification.Call += CallHandler;

        // Регистрация обработчика электронной почты
        notification.Email += EmailHandler;

        // Проверка события сообщения
        notification.SendMessage("Привет!");

        // Проверка события звонка
        notification.SendCall("375291234567");

        // Проверка события электронной почты
        notification.SendEmail("Новое письмо");
    }
}


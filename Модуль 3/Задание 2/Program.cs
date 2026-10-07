using System;

class Notification // уведомление
{
    // метод который передает события 
    // Событие для текстового сообщения
    public event Action<string> Message;

    // Создать событие Call, которое передаёт номер телефона.  
    public event Action<string> Call;

    // Событие для электронной почты
    public event Action<string> Email;

    // Метод отправки сообщения
    public void SendMessage(string text)
    {
        // Вызов события и передача текста
        Message?.Invoke(text);
    }

    // Метод отправки звонка
    public void SendCall(string number)
    {
        // Вызов события и передача номера
        Call?.Invoke(number);
    }

    // Метод отправки письма
    public void SendEmail(string text)
    {
        // Вызов события и передача текста письма
        Email?.Invoke(text);
    }
}

class Program
{

    static void Main()
    {
        // Создание объекта уведомлений
        Notification n = new Notification();

        // При возникновении события выводится текст сообщения
        // Когда произойдёт событие Message, вывести сообщение на экран
        n.Message += text => Console.WriteLine("Сообщение: " + text);

        // Подписка на событие звонка
        // При возникновении события выводится номер телефона
        n.Call += number => Console.WriteLine("Звонок: " + number);

        // Подписка на событие письма
        // При возникновении события выводится текст письма
        n.Email += text => Console.WriteLine("Письмо: " + text);

        // Отправка сообщения
        n.SendMessage("Привет!");

        // Отправка звонка
        n.SendCall("375291234567");

        // Отправка письма
        n.SendEmail("Новое письмо");
    }
}


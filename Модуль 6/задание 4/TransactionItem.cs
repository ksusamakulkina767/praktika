using System;

namespace задание_4
{
    // Одна запись о деньгах: доход или расход
    public class TransactionItem
    {
        public int Id { get; set; }                              // номер записи (уникальный)
        public string Type { get; set; } = "Расход";             // "Доход" или "Расход"
        public string Category { get; set; } = string.Empty;     // категория (например, "Продукты")
        public decimal Amount { get; set; }                      // сумма
        public DateTime Date { get; set; } = DateTime.Now;       // дата (по умолчанию — сейчас)
    }
}
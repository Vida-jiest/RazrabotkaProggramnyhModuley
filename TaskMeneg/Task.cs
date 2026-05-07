using System;

namespace TaskManagerApp
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }

        public Task()
        {
            CreatedAt = DateTime.Now;
            IsCompleted = false;
        }

        public override string ToString()
        {
            string status = IsCompleted ? "✓" : "○";
            return $"[{status}] {Id}. {Title}";
        }

        public string GetFullInfo()
        {
            string status = IsCompleted ? "Выполнено" : "Не выполнено";
            return $"ID: {Id} | Название: {Title} | Описание: {Description} | Статус: {status} | Создано: {CreatedAt:dd.MM.yyyy HH:mm}";
        }
    }
}
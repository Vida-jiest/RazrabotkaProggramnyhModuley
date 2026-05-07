using System;
using System.Collections.Generic;
using System.IO;

namespace TaskManagerApp
{
    public class FileManager
    {
        private readonly string _filePath;

        public FileManager()
        {
            // Путь к рабочему столу
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Файл tasks.txt прямо на рабочем столе
            _filePath = Path.Combine(desktopPath, "tasks.txt");
        }

        public void SaveTasks(List<Task> tasks)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_filePath))
                {
                    foreach (var task in tasks)
                    {
                        // Формат: Id|Title|Description|IsCompleted|CreatedAt
                        writer.WriteLine($"{task.Id}|{task.Title}|{task.Description}|{task.IsCompleted}|{task.CreatedAt}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка сохранения: {ex.Message}");
            }
        }

        public List<Task> LoadTasks()
        {
            List<Task> tasks = new List<Task>();

            try
            {
                if (File.Exists(_filePath))
                {
                    string[] lines = File.ReadAllLines(_filePath);
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length == 5)
                        {
                            Task task = new Task
                            {
                                Id = int.Parse(parts[0]),
                                Title = parts[1],
                                Description = parts[2],
                                IsCompleted = bool.Parse(parts[3]),
                                CreatedAt = DateTime.Parse(parts[4])
                            };
                            tasks.Add(task);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Ошибка загрузки: {ex.Message}");
            }

            return tasks;
        }

        public string GetFilePath()
        {
            return _filePath;
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class FileManager
{
    private string filePath = "tasks.json";

    public void SaveTasks(List<Task> tasks)
    {
        try
        {
            string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(filePath, json);
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка при сохранении задач: {ex.Message}");
        }
    }

    public List<Task> LoadTasks()
    {
        try
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Task>>(json) ?? new List<Task>();
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка при загрузке задач: {ex.Message}");
        }

        return new List<Task>();
    }
}
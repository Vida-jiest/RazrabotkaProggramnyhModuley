using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagerApp
{
    public class TaskManager
    {
        private List<Task> _tasks;
        private int _nextId;
        private FileManager _fileManager;

        public TaskManager()
        {
            _fileManager = new FileManager();
            _tasks = _fileManager.LoadTasks();
            _nextId = _tasks.Count > 0 ? _tasks.Max(t => t.Id) + 1 : 1;
        }

        public void AddTask(string title, string description)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new Exception("Название задачи не может быть пустым");
            }

            Task task = new Task
            {
                Id = _nextId++,
                Title = title.Trim(),
                Description = description ?? "",
                IsCompleted = false
            };

            _tasks.Add(task);
            _fileManager.SaveTasks(_tasks);
        }

        public void RemoveTask(int taskId)
        {
            Task task = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                _tasks.Remove(task);
                _fileManager.SaveTasks(_tasks);
            }
        }

        public void ToggleComplete(int taskId)
        {
            Task task = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                task.IsCompleted = !task.IsCompleted;
                _fileManager.SaveTasks(_tasks);
            }
        }

        public List<Task> GetAllTasks()
        {
            return _tasks.OrderBy(t => t.IsCompleted).ThenByDescending(t => t.CreatedAt).ToList();
        }

        public Task GetTaskById(int taskId)
        {
            return _tasks.FirstOrDefault(t => t.Id == taskId);
        }
    }
}
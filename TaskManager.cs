using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
class TaskManager
{
    private List<Task> tasks = new List<Task>();
    private int nextId = 1;

    public void AddTask(string description)
    {
        tasks.Add(new Task { Id = nextId++, Description = description, IsCompleted = false });
        Console.WriteLine("Task added successfully.");
    }

    public void ListTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
        }
        else
        {
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }
        }
    }

    public void MarkTaskAsCompleted(int id)
    {
        var task = tasks.Find(t => t.Id == id);
        if (task != null)
        {
            task.IsCompleted = true;
            Console.WriteLine($"Task {id} marked as completed.");
        }
        else
        {
            Console.WriteLine($"Task with id {id} not found.");
        }
    }

    public void DeleteTask(int id)
    {
        var task = tasks.Find(t => t.Id == id);
        if (task != null)
        {
            tasks.Remove(task);
            Console.WriteLine($"Task {id} deleted.");
        }
        else
        {
            Console.WriteLine($"Task with id {id} not found.");
        }
    }
}
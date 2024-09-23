using Npgsql;
using System;

class TaskManager
{
    private string connectionString;

    public TaskManager(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void AddTask(string description)
    {
        using (var con = new NpgsqlConnection(connectionString))
        {
            con.Open();
            using (var cmd = new NpgsqlCommand("INSERT INTO tasks (description) VALUES (@description)", con))
            {
                cmd.Parameters.AddWithValue("description", description);
                cmd.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Task added successfully.");
    }

    public void ListTasks()
    {
        using (var con = new NpgsqlConnection(connectionString))
        {
            con.Open();
            using (var cmd = new NpgsqlCommand("SELECT id, description, is_completed FROM tasks", con))
            using (var reader = cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    Console.WriteLine("No tasks available.");
                    return;
                }

                while (reader.Read())
                {
                    var task = new Task
                    {
                        Id = reader.GetInt32(0),
                        Description = reader.GetString(1),
                        IsCompleted = reader.GetBoolean(2)
                    };
                    Console.WriteLine(task);
                }
            }
        }
    }

    public void MarkTaskAsCompleted(int id)
    {
        using (var con = new NpgsqlConnection(connectionString))
        {
            con.Open();
            using (var cmd = new NpgsqlCommand("UPDATE tasks SET is_completed = TRUE WHERE id = @id", con))
            {
                cmd.Parameters.AddWithValue("id", id);
                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows > 0)
                {
                    Console.WriteLine($"Task {id} marked as completed.");
                }
                else
                {
                    Console.WriteLine($"Task with id {id} not found.");
                }
            }
        }
    }

    public void DeleteTask(int id)
    {
        using (var con = new NpgsqlConnection(connectionString))
        {
            con.Open();
            using (var cmd = new NpgsqlCommand("DELETE FROM tasks WHERE id = @id", con))
            {
                cmd.Parameters.AddWithValue("id", id);
                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows > 0)
                {
                    Console.WriteLine($"Task {id} deleted.");
                }
                else
                {
                    Console.WriteLine($"Task with id {id} not found.");
                }
            }
        }
    }
}

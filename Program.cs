class Program
{
    static void Main(string[] args)
    {
        var cs = "Host=localhost;Username=myuser;Password=mypassword;Database=postgres";
        TaskManager taskManager = new TaskManager(cs);
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nTask Manager:");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. List Tasks");
            Console.WriteLine("3. Mark Task as Completed");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Enter task description: ");
                    string description = Console.ReadLine();
                    taskManager.AddTask(description);
                    break;
                case "2":
                    taskManager.ListTasks();
                    break;
                case "3":
                    Console.Write("Enter task ID to mark as completed: ");
                    if (int.TryParse(Console.ReadLine(), out int completedId))
                    {
                        taskManager.MarkTaskAsCompleted(completedId);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    break;
                case "4":
                    Console.Write("Enter task ID to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteId))
                    {
                        taskManager.DeleteTask(deleteId);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }
}

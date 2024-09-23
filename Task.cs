using System;
using System.Collections.Generic;
class Task
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }

    public override string ToString()
    {
        return $"{Id}. {Description} - {(IsCompleted ? "Completed" : "Pending")}";
    }
}
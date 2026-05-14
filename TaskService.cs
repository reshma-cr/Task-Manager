using System.Diagnostics.Contracts;

public static class TaskService
{
    //old way to define a list as a class property
    //public static List<string> {get; set;} = new List<string>(); 
    public static List<Task> Tasks {get; set;} = []; //new way

    public static void CreateTask(string title, string description){
        Task task = new Task()
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = description
        };
        Tasks.Add(task);
    }

    public static void ViewTasks()
    {
        Console.WriteLine("== YOUR TASKS ==");
        foreach(var task in Tasks)
        {
            Console.Write($"Id: {task.Id} | ");
            Console.Write($"Title: {task.Title} | ");
            Console.Write($"Description: {task.Description} | ");
            if (task.IsCompleted)
            {
                Console.Write($"Status: [x]");
            }
            else
            {
                Console.Write($"Status: []");
            }  
            Console.WriteLine();
        }
    }

    public static void DeleteTask(Guid taskId)
    {
        bool found = false;
        foreach(var task in Tasks)
        {
            if(task.Id == taskId)
            {
                found = true;
                Tasks.Remove(task);
                break;
            }
        }
        if (found)
        {
            Console.WriteLine("Task has been deleted successfully.");
        }
        else
        {
            Console.WriteLine("Given Id couldn't be found.");
        }
    }

    public static void ToggleTask(Guid taskId)
    {
        bool found = false;
        foreach(var task in Tasks)
        {
            if(task.Id == taskId)
            {
                found = true;
                task.IsCompleted = !task.IsCompleted;
                break;
            }
        }
        if (found)
        {
            Console.WriteLine("Task was successfully toggled.");
        }
        else
        {
            Console.WriteLine("Given Id couldn't be found.");
            
        }
    }
}
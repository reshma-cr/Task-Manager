public static class TaskService
{
    //old way to define a list as a class property
    //public static List<string> {get; set;} = new List<string>(); 
    public static List<Task> Tasks {get; set;} = []; //new way

    public static void CreateTask(string title, string description){
        if (String.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Title is required.");
            return;
        }
        else if (String.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("Description is required.");
            return;
        }
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
        Console.WriteLine("ID\t\t\t\t\tSTATUS\tTITLE\t\t\tDESCRIPTION");
        Console.WriteLine("---------------------------------------------------------------------------");
        int total = Tasks.Count();
        if(total == 0)
        {
            Console.WriteLine("No tasts to display.");
            return;
        }
        int completed = 0;
        foreach(var task in Tasks)
        {
            if (task.IsCompleted)
            {
                completed++;
                Console.WriteLine($"{task.Id}\t[x]\t{task.Title}\t\t{task.Description}");
            }
            else
            {
                Console.WriteLine($"{task.Id}\t[ ]\t{task.Title}\t\t{task.Description}");
            }
        }
        int pending = total - completed;
        Console.WriteLine("---------------------------------------------------------------------------");
        Console.WriteLine($"Total: {total} | Completed: {completed} | Pending : {pending}");
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
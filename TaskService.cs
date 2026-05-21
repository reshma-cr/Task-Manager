public class TaskService
{
    //old way to define a list as a class property
    //public static List<string> {get; set;} = new List<string>(); 
    public List<Task> Tasks {get; set;} = []; //new way

    public void CreateTask(string title, string description){
        Task task = new Task()
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = description
        };
        Tasks.Add(task);
    }

    public List<Task> GetTasks()
    {
        return Tasks;
    }

    public List<Task> ViewCompletedTasks()
    {
        List<Task> completedTasks = Tasks.Where(t => t.IsCompleted).ToList();
        return completedTasks;
    }

    public void DeleteTask(Guid taskId)
    {
        foreach(var task in Tasks)
        {
            if(task.Id == taskId)
            {
                Tasks.Remove(task);
                break;
            }
        }
    }

    public void ToggleTask(Guid taskId)
    {
        foreach(var task in Tasks)
        {
            if(task.Id == taskId)
            {
                task.IsCompleted = !task.IsCompleted;
                break;
            }
        }
    }
}
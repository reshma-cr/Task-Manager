using TaskManager.Domain;

namespace TaskManager.Application;
public class TaskService : ITaskService
{
    //old way to define a list as a class property
    //public static List<string> {get; set;} = new List<string>(); 
    public List<TaskItem> Tasks {get; set;} = []; //new way

    public TaskItem CreateTask(string title, string description){
        TaskItem task = new TaskItem()
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = description
        };
        Tasks.Add(task);
        return task;
    }

    public List<TaskItem> GetAllTasks()
    {
        return Tasks;
    }

    public TaskItem GetTask(Guid id)
    {
        var tasks = GetAllTasks();
        var task = tasks.FirstOrDefault(t => t.Id == id);
        return task;    
    }

    public bool DeleteTask(Guid taskId)
    {
        var found = false;
        foreach(var task in Tasks)
        {
            if(task.Id == taskId)
            {
                found = true;
                Tasks.Remove(task);
                return found;
            }
        }
        return found;
    }

    public bool ToggleTask(Guid taskId)
    {
        var found = false;
        foreach(var task in Tasks)
        {
            if(task.Id == taskId)
            {
                found = true;
                task.IsCompleted = !task.IsCompleted;
                return found;
            }
        }
        return found;
    }
}
public class TaskService
{
    //old way to define a list as a class property
    //public static List<string> {get; set;} = new List<string>(); 
    public List<Task> Tasks {get; set;} = []; //new way

    public Task CreateTask(string title, string description){
        Task task = new Task()
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = description
        };
        Tasks.Add(task);
        return task;
    }

    public List<Task> GetAllTasks()
    {
        return Tasks;
    }

    public Task GetTask(Guid id)
    {
        var tasks = GetAllTasks();
        var task = tasks.FirstOrDefault(t => t.Id == id);
        return task;    
    }

    public List<Task> ViewCompletedTasks()
    {
        List<Task> completedTasks = Tasks.Where(t => t.IsCompleted).ToList();
        return completedTasks;
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
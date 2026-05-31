using TaskManager.Domain;

namespace TaskManager.Application;

public interface ITaskService
{
    TaskItem CreateTask(string title, string description);

    List<TaskItem> GetAllTasks();

    TaskItem GetTask(Guid id);

    bool DeleteTask(Guid taskId);

    bool ToggleTask(Guid taskId);
}

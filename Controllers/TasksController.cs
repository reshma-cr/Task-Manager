using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly TaskService _taskService;

    public TasksController(TaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public ActionResult GetTasks(){
        var tasks = _taskService.GetTasks();
        return Ok(tasks);
    }

    [HttpPost]
    public ActionResult<IEnumerable<Task>> CreateTask()
    {
        
    }

}

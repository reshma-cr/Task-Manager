using Microsoft.AspNetCore.Mvc;
using TaskManager.Domain;
using TaskManager.Application;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public ActionResult GetAllTasks(){
        var tasks = _taskService.GetAllTasks();
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public ActionResult<TaskItem> GetTask(Guid id)
    {
        var task = _taskService.GetTask(id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }

    [HttpPost]
    public ActionResult<TaskItem> CreateTask([FromBody] TaskItem task)
    {
        if (task == null || string.IsNullOrWhiteSpace(task.Title) || string.IsNullOrWhiteSpace(task.Description))
        {
            return BadRequest("Task title and description cannot be empty.");
        }
        var createdTask = _taskService.CreateTask(task.Title, task.Description);
        return CreatedAtAction(nameof(GetTask), new { id = createdTask.Id }, createdTask);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteTask(Guid id)
    {
        if (!_taskService.DeleteTask(id))
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpPatch("{id}/complete")]
    public ActionResult ToggleTask(Guid id)
    {
        if (!_taskService.ToggleTask(id))
        {
            return NotFound();
        }
        return NoContent();
    }

}

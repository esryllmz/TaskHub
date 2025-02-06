using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;


namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        private readonly ITaskItemService _TaskItemService;

        public TaskItemsController(ITaskItemService TaskItemService)
        {
            _TaskItemService = TaskItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTaskItems()
        {
            var TaskItems = await _TaskItemService.GetAllTaskItemsAsync();
            return Ok(TaskItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskItem(int id)
        {
            var TaskItem = await _TaskItemService.GetTaskItemByIdAsync(id);
            if (TaskItem == null) return NotFound();
            return Ok(TaskItem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskItem(TaskItem taskItem)
        {
            var createdTaskItem = await _TaskItemService.CreateTaskItemAsync(taskItem);
            return CreatedAtAction(nameof(GetTaskItem), new { id = createdTaskItem.Id }, createdTaskItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskItem(int id, TaskItem TaskItem)
        {
            var updatedTaskItem = await _TaskItemService.UpdateTaskItemAsync(id, TaskItem);
            if (updatedTaskItem == null) return NotFound();
            return Ok(updatedTaskItem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskItem(int id)
        {
            var success = await _TaskItemService.DeleteTaskItemAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}

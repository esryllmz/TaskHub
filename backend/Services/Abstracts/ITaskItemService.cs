using backend.Models;

namespace backend.Services
{
    public interface ITaskItemService
    {
        Task<List<TaskItem>> GetAllTaskItemsAsync();

        Task<TaskItem?> GetTaskItemByIdAsync(int id);

        Task<TaskItem> CreateTaskItemAsync(TaskItem taskItem);

        Task<TaskItem?> UpdateTaskItemAsync(int id, TaskItem updatedTaskItem);

        Task<bool> DeleteTaskItemAsync(int id);
    }
}

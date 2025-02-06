using backend.Models;

namespace backend.Data.Abstracts;

public interface ITaskItemDataAccess
{
    Task<List<TaskItem>> GetAllAsync();
    Task<TaskItem?> GetByIdAsync(int id);
    Task<TaskItem> AddAsync(TaskItem taskItem);
    Task<TaskItem> UpdateAsync(TaskItem taskItem);
    Task<bool> DeleteAsync(int id);
}

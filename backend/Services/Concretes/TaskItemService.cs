using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;

namespace backend.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly AppDbContext _context;

        public TaskItemService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TaskItem> CreateTaskItemAsync(TaskItem taskItem)
        {
            _context.TaskItems.Add(taskItem);
            await _context.SaveChangesAsync();
            return taskItem;
        }

        public async Task<bool> DeleteTaskItemAsync(int id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem == null) return false;

            _context.TaskItems.Remove(taskItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<TaskItem>> GetAllTaskItemsAsync()
        {
            return await _context.TaskItems.Include(t => t.User).ToListAsync();
        }

        public async Task<TaskItem?> GetTaskItemByIdAsync(int id)
        {
            var taskItem = await _context.TaskItems.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == id);
            if (taskItem == null)
            {
                throw new Exception($"TaskItem with ID {id} not found.");
            }
            return taskItem;
        }

        public async Task<TaskItem?> UpdateTaskItemAsync(int id, TaskItem updatedTaskItem)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem == null) return null;

            taskItem.Title = updatedTaskItem.Title;
            taskItem.Description = updatedTaskItem.Description;
            taskItem.IsCompleted = updatedTaskItem.IsCompleted;
            taskItem.UserId = updatedTaskItem.UserId;

            await _context.SaveChangesAsync();
            return taskItem;
        }
    }
}

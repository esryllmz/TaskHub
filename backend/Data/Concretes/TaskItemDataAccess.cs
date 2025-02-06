using backend.Data;
using backend.Data.Abstracts;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data.Concretes;

public class TaskItemDataAccess : ITaskItemDataAccess
{
    private readonly AppDbContext _context;

    public TaskItemDataAccess(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TaskItem>> GetAllAsync()
    {
        return await _context.TaskItems.Include(t => t.User).ToListAsync();
    }

    public async Task<TaskItem?> GetByIdAsync(int id)
    {
        return await _context.TaskItems.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<TaskItem> AddAsync(TaskItem taskItem)
    {
        await _context.TaskItems.AddAsync(taskItem);
        await _context.SaveChangesAsync();
        return taskItem;
    }

    public async Task<TaskItem> UpdateAsync(TaskItem taskItem)
    {
        var existingTaskItem = await _context.TaskItems.FindAsync(taskItem.Id);
        if (existingTaskItem == null) throw new Exception($"TaskItem with ID {taskItem.Id} not found.");

        existingTaskItem.Title = taskItem.Title;
        existingTaskItem.Description = taskItem.Description;
        existingTaskItem.IsCompleted = taskItem.IsCompleted;
        existingTaskItem.UserId = taskItem.UserId;

        await _context.SaveChangesAsync();
        return existingTaskItem;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var taskItem = await _context.TaskItems.FindAsync(id);
        if (taskItem == null) return false;

        _context.TaskItems.Remove(taskItem);
        await _context.SaveChangesAsync();
        return true;
    }
}

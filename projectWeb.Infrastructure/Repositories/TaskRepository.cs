using projectWeb.Application.Interfaces;
using Task = projectWeb.Domain.Entities.Task;

namespace projectWeb.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }
    public  async Task<int> AddAsync(projectWeb.Domain.Entities.Task task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task.Id;
    }
}
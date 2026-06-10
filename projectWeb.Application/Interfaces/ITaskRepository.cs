namespace projectWeb.Application.Interfaces;

public interface ITaskRepository
{
    Task<int> AddAsync(projectWeb.Domain.Entities.Task task);
}
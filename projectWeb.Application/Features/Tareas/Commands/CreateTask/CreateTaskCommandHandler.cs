using MediatR;
using projectWeb.Domain.Entities;
using projectWeb.Application.Interfaces;

namespace projectWeb.Application.Features.Tareas.Commands.CreateTask;

// Implementa IRequestHandler: Recibe el comando y devuelve el ID entero generado
public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
{
    private readonly ITaskRepository _repository;
    

    // Inyectamos la INTERFAZ, no el DbContext externo
    public CreateTaskCommandHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var nuevaTarea = new projectWeb.Domain.Entities.Task
        {
            Title = request.Title,
            Description = request.Description,
            UserId = request.UserId,
            Status = "Pendiente",
            CreatedAt = DateTime.UtcNow
        };

        // Le delegamos el guardado al repositorio externo
        return await _repository.AddAsync(nuevaTarea);
    }
}
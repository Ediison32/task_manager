using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using MediatR;
using projectWeb.Application.DTOs;
using projectWeb.Application.Interfaces;

namespace projectWeb.Application.Features.Tareas.Queries.GetTasks;

public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, List<TaskDto>>
{
    private readonly ITaskRepository _repository;
    // intectamos la interfaz manteniendo la capa limpia

    public GetTasksQueryHandler(ITaskRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<TaskDto>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
    {
        // 1. Le pedimos las tareas al repositorio externo
        var tareasEntidad = await _repository.GetAllAsync();

        // 2. Las mapeamos manualmente a nuestro TareaDto
        var listaTareasDto = tareasEntidad.Select(t => new TaskDto()
        {
            Id = t.Id,
            Titulo = t.Title,
            Descripcion = t.Description,
            Estado = t.Status
        }).ToList();

        return listaTareasDto;
    }
}
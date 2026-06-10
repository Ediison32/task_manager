using MediatR;
using projectWeb.Application.DTOs;

namespace projectWeb.Application.Features.Tareas.Queries.GetTasks;

public record GetTasksQuery(): IRequest<List<TaskDto>>;
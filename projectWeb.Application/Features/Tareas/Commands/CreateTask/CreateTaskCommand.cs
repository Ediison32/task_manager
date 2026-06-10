using MediatR;

namespace projectWeb.Application.Features.Tareas.Commands.CreateTask;

public record CreateTaskCommand(string Title, string Description, int UserId): IRequest<int>;
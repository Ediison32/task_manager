using MediatR;

namespace projectWeb.Application.Features.Tareas.Commands.CreateUser;

public record CreateUserCommand(string Name, string Email) : IRequest<int>;

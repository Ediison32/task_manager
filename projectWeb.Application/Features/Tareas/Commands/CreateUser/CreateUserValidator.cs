using System.Data;
using FluentValidation;

namespace projectWeb.Application.Features.Tareas.Commands.CreateUser;

public class CreateUserValidator: AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(u => u.Name)
            .NotEmpty().WithMessage("El nombre no puede estar vacio ");

        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("El correo no puede estar vacio");
        
    }
}
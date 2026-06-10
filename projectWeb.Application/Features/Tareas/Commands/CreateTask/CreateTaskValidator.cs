using FluentValidation;

namespace projectWeb.Application.Features.Tareas.Commands.CreateTask;

public class CreateTaskValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("El titulo de la tarea no puede esta vacio ");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("La descriopcion es obligatoria");

        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("Debes asignar un Id de usario valido ");
        
    }
}
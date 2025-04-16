using FluentValidation;

namespace Application.Features.Solicitudes.Commands.CreateSolicitud;

public sealed class CreateSolicitudCommandValidator : AbstractValidator<CreateSolicitudCommand>
{
    public CreateSolicitudCommandValidator()
    {
        RuleFor(x => x.Solicitante)
            .NotEmpty()
            .WithMessage("El nombre del solicitante es requerido")
            .NotNull()
            .WithMessage("El nombre del solicitante es requerido");
    }
}

using FluentValidation;

namespace Application.Features.Solicitudes.Commands.UpdateSolicitud;

public sealed class UpdateSolicitudCommandValidator : AbstractValidator<UpdateSolicitudCommand>
{
    public UpdateSolicitudCommandValidator()
    {
        RuleFor(x => x.Solicitante)
            .NotEmpty()
            .WithMessage("El nombre del solicitante es requerido")
            .NotNull()
            .WithMessage("El nombre del solicitante es requerido");


        RuleFor(x => x.IdEstado)
            .NotNull()
            .WithMessage("El Estado de la solicitud es requerido")
            .LessThan(4)
            .WithMessage("El estado de la solicitud no se encuentra entre los definididos por el sistema");
    }
}

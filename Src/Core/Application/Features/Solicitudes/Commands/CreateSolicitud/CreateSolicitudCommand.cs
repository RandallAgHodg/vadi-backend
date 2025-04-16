using Application.Common.Messaging;

namespace Application.Features.Solicitudes.Commands.CreateSolicitud;

public sealed record CreateSolicitudCommand (string Solicitante) : ICommand<bool>;

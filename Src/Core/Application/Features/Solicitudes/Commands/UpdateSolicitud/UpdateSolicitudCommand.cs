using Application.Common.Messaging;
using System.Windows.Input;

namespace Application.Features.Solicitudes.Commands.UpdateSolicitud;

public sealed record UpdateSolicitudCommand(int Id, string Solicitante, int IdEstado) : ICommand<bool>;
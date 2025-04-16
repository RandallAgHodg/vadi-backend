using Application.Features.Solicitudes.Commands.UpdateSolicitud;
using Domain.Common.Contracts.Data;

namespace Application.Mapping;

public static class MessagingToDtoMapper
{
    public static UpdateSolicitudDto ToDto(this UpdateSolicitudCommand command) =>
        new UpdateSolicitudDto(command.Id, command.Solicitante, command.IdEstado);

}

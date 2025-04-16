using Application.Features.Solicitudes.Commands.CreateSolicitud;
using Application.Features.Solicitudes.Commands.UpdateSolicitud;
using Domain.Common.Contracts.Request;

namespace Application.Mapping;

public static class ApiContractToMessage
{
    public static CreateSolicitudCommand ToSolicitudCommand(this CreateSolicitudRequest request) =>
        new CreateSolicitudCommand(request.Solicitante);

    public static UpdateSolicitudCommand ToSolicitudCommand(this UpdateSolicitudRequest request, int Id) =>
        new UpdateSolicitudCommand(Id, request.Solicitante, request.IdEstado);
}

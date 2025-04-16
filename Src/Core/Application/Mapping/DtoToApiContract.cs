using Domain.Common.Contracts.Data;
using Domain.Common.Contracts.Response;

namespace Application.Mapping;

public static class DtoToApiContract
{
    public static SolicitudResponse ToSolicitudResponse(this SolicitudDto dto) =>
        new SolicitudResponse(dto.Id, dto.Solicitante, dto.FechaSolicitud, dto.Estado);
    public static IEnumerable<SolicitudResponse> ToSolicitudesResponse(this IEnumerable<SolicitudDto> dtos) =>
        dtos.Select(dto => dto.ToSolicitudResponse());
}

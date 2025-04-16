using Application.Common.DataAccess;
using Application.Common.Messaging;
using Application.Mapping;
using Domain.Common.Contracts.Response;

namespace Application.Features.Solicitudes.Queries.GetSolicitudByQuerySearch;

public sealed class GetSolicitudByQuerySearchHandler : IQueryHandler<GetSolicitudByQuerySearch, IEnumerable<SolicitudResponse>>
{
    private readonly ISolicitudRepository _solicitudRepository;
    
    public GetSolicitudByQuerySearchHandler(ISolicitudRepository solicitudRepository) =>
        _solicitudRepository = solicitudRepository;

    public async Task<IEnumerable<SolicitudResponse>> Handle(GetSolicitudByQuerySearch request, CancellationToken cancellationToken)
    {
        var data = await _solicitudRepository.GetSolicitudByQueryAsync(request.querySearch);

        var response = data.ToSolicitudesResponse();

        return response;
    }
}

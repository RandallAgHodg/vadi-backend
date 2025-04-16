using Application.Common.DataAccess;
using Application.Common.Messaging;
using Application.Mapping;
using Domain.Common.Contracts.Response;

namespace Application.Features.Request.Queries;

public sealed class GetAllSolicitudesQueryHandler : IQueryHandler<GetAllSolicitudesQuery, IEnumerable<SolicitudResponse>>
{
    private readonly ISolicitudRepository _solicitudRepository;
    
    public GetAllSolicitudesQueryHandler(ISolicitudRepository solicitudRepository) =>
        _solicitudRepository = solicitudRepository;

    public async Task<IEnumerable<SolicitudResponse>> Handle(GetAllSolicitudesQuery request, CancellationToken cancellationToken)
    {
        var data = await _solicitudRepository.GetSolicitudesAsync();

        var response = data.ToSolicitudesResponse();

        return response;
    }
}

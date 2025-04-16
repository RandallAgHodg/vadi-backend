using Application.Common.DataAccess;
using Application.Common.Messaging;
using Application.Mapping;
using Domain.Common.Contracts.Response;

namespace Application.Features.Estados.Queries;

public sealed class GetAllEstadosQueryHandler : IQueryHandler<GetAllEstadosQuery, IEnumerable<EstadoResponse>>
{
    private readonly IEstadoRepository _estadoRepository;

    public GetAllEstadosQueryHandler(IEstadoRepository estadoRepository) =>
        _estadoRepository = estadoRepository;

    public async Task<IEnumerable<EstadoResponse>> Handle(GetAllEstadosQuery request, CancellationToken cancellationToken)
    {
        var data = await _estadoRepository.GetEstadosAsync();

        var response = data.ToEstadosResponse();

        return response;
    }
}

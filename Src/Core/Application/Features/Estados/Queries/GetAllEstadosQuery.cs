using Application.Common.Messaging;
using Domain.Common.Contracts.Response;

namespace Application.Features.Estados.Queries;

public sealed class GetAllEstadosQuery : IQuery<IEnumerable<EstadoResponse>>
{
}

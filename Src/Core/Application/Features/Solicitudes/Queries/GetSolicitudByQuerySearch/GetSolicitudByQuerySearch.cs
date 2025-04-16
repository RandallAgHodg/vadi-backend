using Application.Common.Messaging;
using Domain.Common.Contracts.Response;

namespace Application.Features.Solicitudes.Queries.GetSolicitudByQuerySearch;

public sealed record GetSolicitudByQuerySearch (string querySearch) : IQuery<IEnumerable<SolicitudResponse>>;

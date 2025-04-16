using Application.Common.Messaging;
using Domain.Common.Contracts.Response;

namespace Application.Features.Request.Queries;

public sealed class GetAllSolicitudesQuery : IQuery<IEnumerable<SolicitudResponse>> { };

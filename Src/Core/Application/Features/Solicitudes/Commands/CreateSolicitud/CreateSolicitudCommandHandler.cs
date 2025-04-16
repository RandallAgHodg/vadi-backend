using Application.Common.DataAccess;
using Application.Common.Messaging;
using Domain.Common.Contracts.Data;

namespace Application.Features.Solicitudes.Commands.CreateSolicitud;

public sealed class CreateSolicitudCommandHandler : ICommandHandler<CreateSolicitudCommand, bool>
{
    private readonly ISolicitudRepository _solicitudRepository;

    public CreateSolicitudCommandHandler(ISolicitudRepository solicitudRepository) =>
        _solicitudRepository = solicitudRepository;

    public async Task<bool> Handle(CreateSolicitudCommand request, CancellationToken cancellationToken) =>
        await _solicitudRepository.CreateSolicitudAsync(new CreateSolicitudDto(request.Solicitante));
}

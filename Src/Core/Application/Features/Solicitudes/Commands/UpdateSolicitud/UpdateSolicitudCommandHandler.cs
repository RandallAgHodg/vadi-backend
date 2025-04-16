using Application.Common.DataAccess;
using Application.Common.Messaging;
using Application.Mapping;

namespace Application.Features.Solicitudes.Commands.UpdateSolicitud;

public sealed class UpdateSolicitudCommandHandler : ICommandHandler<UpdateSolicitudCommand, bool>
{
    private readonly ISolicitudRepository _solicitudRepository;
    
    public UpdateSolicitudCommandHandler(ISolicitudRepository solicitudRepository) =>
        _solicitudRepository = solicitudRepository;

    public async Task<bool> Handle(UpdateSolicitudCommand request, CancellationToken cancellationToken) =>
        await _solicitudRepository.UpdateSolicitudAsync(request.ToDto());
}

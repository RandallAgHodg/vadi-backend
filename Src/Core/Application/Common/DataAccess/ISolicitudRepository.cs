using Domain.Common.Contracts.Data;
namespace Application.Common.DataAccess;

public interface ISolicitudRepository
{
    Task<IEnumerable<SolicitudDto>> GetSolicitudesAsync();
    Task<IEnumerable<SolicitudDto>> GetSolicitudByQueryAsync(string query);
    Task<bool> CreateSolicitudAsync(CreateSolicitudDto dto);
    Task<bool> UpdateSolicitudAsync(UpdateSolicitudDto dto);
}
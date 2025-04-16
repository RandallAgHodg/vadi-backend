using Domain.Common.Contracts.Data;

namespace Application.Common.DataAccess;

public interface IEstadoRepository
{
    Task<IEnumerable<EstadoDto>> GetEstadosAsync();
}

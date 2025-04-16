using Application.Common.DataAccess;
using Dapper;
using Domain.Common.Contracts.Data;
using System.Data;

namespace DataAccess.Repositories;

public sealed class EstadoRepository : IEstadoRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public EstadoRepository(IDbConnectionFactory connectionFactory) =>
        _connectionFactory = connectionFactory;

    public async Task<IEnumerable<EstadoDto>> GetEstadosAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();

        const string procedure = "sp_Estado_ObtenerTodos";

        var data = await connection.QueryAsync<EstadoDto>
               (procedure,
                   commandType: CommandType.StoredProcedure);

        return data;
    }
}

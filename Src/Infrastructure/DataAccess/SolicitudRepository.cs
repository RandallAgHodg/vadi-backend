using Application.Common.DataAccess;
using System.Data.Common;
using System.Data;
using Dapper;
using Domain.Common.Contracts.Data;
using Domain.Common.Contracts.Response;
using Microsoft.Data.SqlClient;

namespace Infrastructure.DataAccess;

public class SolicitudRepository : ISolicitudRepository
{
    private readonly IDbConnectionFactory _connectionFactory;
    
    public SolicitudRepository(IDbConnectionFactory connectionFactory) =>
        _connectionFactory = connectionFactory;

    public async Task<bool> CreateSolicitudAsync(CreateSolicitudDto dto)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();

        const string procedure = "sp_Solicitudes_Crear";

        var parameters = new DynamicParameters();
        parameters.Add("@Solicitante", dto.Solicitante, DbType.String, ParameterDirection.Input);

        int newId = connection.QuerySingle<int>(
            procedure,
            parameters,
            commandType: CommandType.StoredProcedure
        );

        return newId > 0;
    }

    public async Task<IEnumerable<SolicitudDto>> GetSolicitudByQueryAsync(string query)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        
        const string procedure = "sp_Solicitudes_ObtenerPorSolicitante";
        
        var data = await connection.QueryAsync<SolicitudDto>
            (procedure,
                new { Solicitante = query},
                commandType: CommandType.StoredProcedure);

        return data;
    }

    public async Task<IEnumerable<SolicitudDto>> GetSolicitudesAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();

        const string procedure = "sp_Solicitudes_ObtenerTodas";

        var data = await connection.QueryAsync<SolicitudDto>
               (procedure,
                   commandType: CommandType.StoredProcedure);

        return data;
    }

    public async Task<bool> UpdateSolicitudAsync(UpdateSolicitudDto dto)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();

        const string procedure = "sp_Solicitudes_Actualizar";

        var parameters = new DynamicParameters();
        parameters.Add("@Id", dto.Id, DbType.Int32, ParameterDirection.Input);
        parameters.Add("@Solicitante", dto.Solicitante, DbType.String, ParameterDirection.Input);
        parameters.Add("@IdEstado", dto.IdEstado, DbType.Int32, ParameterDirection.Input);

        int newId = connection.QuerySingle<int>(
            procedure,
            parameters,
            commandType: CommandType.StoredProcedure
        );

        return newId > 0;
    }
}

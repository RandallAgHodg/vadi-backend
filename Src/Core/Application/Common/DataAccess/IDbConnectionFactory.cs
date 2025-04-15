using System.Data;

namespace Application.Common.DataAccess;

public interface IDbConnectionFactory
{
    public Task<IDbConnection> CreateConnectionAsync();
}
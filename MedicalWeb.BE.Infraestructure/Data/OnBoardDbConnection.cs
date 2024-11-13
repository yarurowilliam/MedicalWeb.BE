using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace MedicalWeb.BE.Infrastructure.Data;

public sealed class OnBoardDbConnection(string connectionString) : IOnBoardDbConnection, IDisposable, IAsyncDisposable
{
    private readonly Lazy<SqlConnection> _connection = new Lazy<SqlConnection>(() => new SqlConnection(connectionString));
    public DbConnection Connection => _connection.Value;

    public void Dispose()
    {
        _connection.Value?.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        if (_connection.IsValueCreated)
        {
            await _connection.Value.DisposeAsync();
        }
    }
}

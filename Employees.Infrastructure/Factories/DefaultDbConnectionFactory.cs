using System.Data;
using Employees.Infrastructure.Factories.Interfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Employees.Infrastructure.Factories;

public class DefaultDbConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;
    
    public DefaultDbConnectionFactory(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Connection string \"Default\" has not been found.");
    }
    
    public async Task<IDbConnection> CreateAsync()
    {
        var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();
        return connection;
    }
}
using System.Data;

namespace Employees.Infrastructure.Factories.Interfaces;

public interface IDbConnectionFactory
{
    public Task<IDbConnection> CreateAsync();
}
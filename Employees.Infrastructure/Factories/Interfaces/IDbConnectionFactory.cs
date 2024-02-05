using System.Data;

namespace Employees.Infrastructure.Factories.Interfaces;

public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateAsync();
}
using Dapper;
using Employees.Domain.Entities;
using Employees.Domain.Repositories;
using Employees.Infrastructure.Factories.Interfaces;
using Employees.Infrastructure.Procedures;

namespace Employees.Infrastructure.Repositories;

public class PassportRepository : IPassportRepository
{
    private readonly IDbConnectionFactory _factory;

    public PassportRepository(IDbConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<int> CreateAsync(Passport passport)
    {
        using var connection = await _factory.CreateAsync();

        var result = await connection.ExecuteScalarAsync<int>(SqlProcedures.Passport_Create, passport);

        return result;
    }

    public async Task<bool> ExistsByNumberAndTypeAsync(string number, string type)
    {
        using var connection = await _factory.CreateAsync();

        var result = await connection.ExecuteScalarAsync<int>(SqlProcedures.Passport_ExistsByNumberAndType, new Passport
        {
            Number = number,
            Type = type
        });

        return result > 0;
    }
    
    public async Task UpdateAsync(Passport passport, int id)
    {
        using var connection = await _factory.CreateAsync();

        passport.Id = id;
        
        await connection.ExecuteAsync(SqlProcedures.Passport_Update, passport);
    }

    public async Task<Passport> GetByEmployeeIdAsync(int id)
    {
        using var connection = await _factory.CreateAsync();

        var result = await connection.QueryAsync<Passport>(SqlProcedures.Passport_GetByEmployeeId, new Passport
        {
            EmployeeId = id
        });

        return result.FirstOrDefault();
    }
}
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
    
    public async Task<Passport> GetByIdAsync(int id)
    {
        using var connection = await _factory.CreateAsync();

        var result = await connection.QueryAsync<Passport>(SqlProcedures.Passport_GetById, new Passport
        {
            Id = id
        });

        return result.FirstOrDefault();
    }

    public async Task DeleteByIdAsync(int id)
    {
        using var connection = await _factory.CreateAsync();

        await connection.ExecuteAsync(SqlProcedures.Passport_Delete, new Passport
        {
            Id = id
        });
    }

    public async Task<int> CreateAsync(Passport passport)
    {
        using var connection = await _factory.CreateAsync();

        var result = await connection.ExecuteScalarAsync<int>(SqlProcedures.Passport_Create, passport);

        return result;
    }

    public async Task<bool> ExistsByNumberAsync(string number)
    {
        using var connection = await _factory.CreateAsync();

        var result = await connection.ExecuteScalarAsync<int>(SqlProcedures.Passport_ExistsByNumber, new Passport
        {
            Number = number
        });

        return result > 0;
    }
    
    public async Task UpdateAsync(Passport passport, int id)
    {
        using var connection = await _factory.CreateAsync();

        passport.Id = id;
        
        await connection.ExecuteAsync(SqlProcedures.Passport_Update, passport);
    }
}
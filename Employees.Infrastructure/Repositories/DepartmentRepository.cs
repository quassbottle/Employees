using Dapper;
using Employees.Domain.Entities;
using Employees.Domain.Repositories;
using Employees.Infrastructure.Factories.Interfaces;
using Employees.Infrastructure.Procedures;
using Microsoft.Extensions.Configuration;

namespace Employees.Infrastructure.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly IDbConnectionFactory _factory;
    
    public DepartmentRepository(IDbConnectionFactory factory)
    {
        this._factory = factory;
    }
    
    public async Task<Department> GetByIdAsync(int id)
    {
        using var connection = await _factory.CreateAsync();

        var result = await connection.QueryAsync<Department>(SqlProcedures.Department_GetById, new Department
        {
            Id = id
        });

        return result.FirstOrDefault();
    }

    public async Task DeleteByIdAsync(int id)
    {
        using var connection = await _factory.CreateAsync();

        await connection.ExecuteAsync(SqlProcedures.Department_Delete, new Department
        {
            Id = id
        });
    }

    public async Task<int> CreateAsync(Department department)
    {
        using var connection = await _factory.CreateAsync();

        var result = await connection.ExecuteScalarAsync<int>(SqlProcedures.Department_Create, department);

        return result;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        using var connection = await _factory.CreateAsync();

        var result = await connection.ExecuteScalarAsync<int>(SqlProcedures.Department_Exists, new Department
        {
            Id = id
        });

        return result > 0;
    }

    public async Task UpdateAsync(Department department, int id)
    {
        using var connection = await _factory.CreateAsync();

        department.Id = id;

        await connection.ExecuteAsync(SqlProcedures.Department_Update, department);
    }

    public async Task<IList<Department>> GetAllAsync()
    {
        using var connection = await _factory.CreateAsync();

        var result = await connection.QueryAsync<Department>(SqlProcedures.Department_GetAll);
        
        return result.ToList();
    }
}
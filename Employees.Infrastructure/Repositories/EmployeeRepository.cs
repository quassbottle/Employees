using Dapper;
using Employees.Domain.Entities;
using Employees.Domain.Repositories;
using Employees.Infrastructure.Factories.Interfaces;
using Employees.Infrastructure.Procedures;

namespace Employees.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly IDbConnectionFactory _factory;

    public EmployeeRepository(IDbConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<Employee> GetByIdAsync(int id)
    {
        using var connection = await _factory.CreateAsync();

        var result = await connection.QueryAsync<Employee>(SqlProcedures.Employee_GetById, new
        {
            @Id = id
        });

        return result.FirstOrDefault();
    }

    public async Task DeleteByIdAsync(int id)
    {
        using var connection = await _factory.CreateAsync();

        await connection.ExecuteAsync(SqlProcedures.Employee_Delete, new Employee
        {
            Id = id
        });
    }

    public async Task<int> CreateAsync(Employee employee)
    {
        using var connection = await _factory.CreateAsync();

        var result = await connection.ExecuteScalarAsync<int>(SqlProcedures.Employee_Create, employee);

        return result;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        using var connection = await _factory.CreateAsync();

        var result = await connection.ExecuteScalarAsync<int>(SqlProcedures.Employee_Exists, new Employee
        {
            Id = id
        });

        return result > 0;
    }

    public async Task UpdateAsync(Employee employee, int id)
    {
        using var connection = await _factory.CreateAsync();

        employee.Id = id;

        await connection.ExecuteAsync(SqlProcedures.Employee_Update, employee);
    }

    public async Task<IList<Employee>> GetAllByCompanyIdAsync(int companyId)
    {
        using var connection = await _factory.CreateAsync();

        var result = await connection.QueryAsync<Employee>(SqlProcedures.Employee_GetAllByCompanyId, new Employee
        {
            CompanyId = companyId
        });

        return result.ToList();
    }

    public async Task<IList<Employee>> GetAllByDepartmentIdAsync(int departmentId)
    {
        using var connection = await _factory.CreateAsync();

        var result = await connection.QueryAsync<Employee>(SqlProcedures.Employee_GetAllByDepartmentId, new Employee
        {
            DepartmentId = departmentId
        });

        return result.ToList();
    }
}
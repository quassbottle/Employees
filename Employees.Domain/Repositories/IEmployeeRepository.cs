using Employees.Domain.Entities;

namespace Employees.Domain.Repositories;

public interface IEmployeeRepository
{
    Task<Employee> GetByIdAsync(int id);
    Task DeleteByIdAsync(int id);
    Task<int> CreateAsync(Employee employee);
    Task UpdateAsync(Employee employee, int id);
    Task<IList<Employee>> GetAllByCompanyIdAsync(int companyId);
    Task<IList<Employee>> GetAllByDepartmentIdAsync(int departmentId);
}
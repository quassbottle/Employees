using Employees.Domain.Entities;

namespace Employees.Domain.Repositories;

public interface IEmployeeRepository
{
    public Task<Employee> GetByIdAsync(int id);
    public Task DeleteByIdAsync(int id);
    public Task<int> CreateAsync(Employee employee);
    public Task UpdateAsync(Employee employee, int id);
    public Task<IList<Employee>> GetAllByCompanyIdAsync(int companyId);
    public Task<IList<Employee>> GetAllByDepartmentIdAsync(int departmentId);
}
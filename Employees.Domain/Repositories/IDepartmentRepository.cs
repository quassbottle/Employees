using Employees.Domain.Entities;

namespace Employees.Domain.Repositories;

public interface IDepartmentRepository
{
    Task<Department> GetByIdAsync(int id);
    Task DeleteByIdAsync(int id);
    Task<int> CreateAsync(Department department);
    Task<bool> ExistsAsync(int id);
    Task UpdateAsync(Department department, int id);
    Task<IList<Department>> GetAllAsync();
}
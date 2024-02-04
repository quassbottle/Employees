using Employees.Domain.Entities;

namespace Employees.Domain.Repositories;

public interface IDepartmentRepository
{
    public Task<Department> GetByIdAsync(int id);
    public Task DeleteByIdAsync(int id);
    public Task<int> CreateAsync(Department department);
    public Task<bool> ExistsAsync(int id);
    public Task UpdateAsync(Department department, int id);
    public Task<IList<Department>> GetAllAsync();
}
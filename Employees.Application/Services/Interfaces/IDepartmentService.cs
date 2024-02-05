using Employees.Application.Dto;

namespace Employees.Application.Services.Interfaces;

public interface IDepartmentService
{
    public Task<int> CreateAsync(DepartmentDto departmentDto);
    public Task<DepartmentDto> GetByIdAsync(int id);
    public Task UpdateAsync(DepartmentDto departmentDto, int id);
    public Task DeleteAsync(int id);
    public Task<IList<DepartmentDto>> GetAllAsync();
}
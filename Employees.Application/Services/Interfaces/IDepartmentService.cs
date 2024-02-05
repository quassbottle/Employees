using Employees.Application.Dto;

namespace Employees.Application.Services.Interfaces;

public interface IDepartmentService
{
    Task<int> CreateAsync(DepartmentDto departmentDto);
    Task<DepartmentDto> GetByIdAsync(int id);
    Task UpdateAsync(DepartmentDto departmentDto, int id);
    Task DeleteAsync(int id);
    Task<IList<DepartmentDto>> GetAllAsync();
}
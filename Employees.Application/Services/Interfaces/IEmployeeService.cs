using Employees.Application.Dto;

namespace Employees.Application.Services.Interfaces;

public interface IEmployeeService
{
    public Task<int> CreateAsync(EmployeeDto employeeDto);
    public Task<EmployeeDto> GetByIdAsync(int id);
    public Task UpdateAsync(EmployeeDto employeeDto, int id);
    public Task DeleteAsync(int id);
    
    public Task<IList<EmployeeDto>> GetAllByCompanyIdAsync(int id);
    public Task<IList<EmployeeDto>> GetAllByDepartmentIdAsync(int id);
}
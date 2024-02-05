using Employees.Application.Dto;

namespace Employees.Application.Services.Interfaces;

public interface IEmployeeService
{
    Task<int> CreateAsync(EmployeeDto employeeDto);
    Task<EmployeeDto> GetByIdAsync(int id);
    Task UpdateAsync(EmployeeDto employeeDto, int id);
    Task DeleteAsync(int id);
    Task<IList<EmployeeDto>> GetAllByCompanyIdAsync(int id);
    Task<IList<EmployeeDto>> GetAllByDepartmentIdAsync(int id);
}
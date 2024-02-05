using Employees.Application.Contracts.Passport;
using Employees.Application.Dto;

namespace Employees.Application.Contracts.Employee;

public class EmployeeUpdateRequest
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Phone { get; set; }
    public int? CompanyId { get; set; }  
    public PassportUpdateRequest? Passport { get; set; }
    public DepartmentUpdateRequest? Department { get; set; }
}
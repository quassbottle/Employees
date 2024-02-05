using Employees.Application.Contracts.Passport;
using Employees.Application.Dto;

namespace Employees.Application.Contracts.Employee;

public class EmployeeCreateRequest
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public int CompanyId { get; set; }  
    public int DepartmentId { get; set; }
    public PassportCreateRequest Passport { get; set; }
}
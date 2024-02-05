using System.ComponentModel.DataAnnotations;
using Employees.Application.Contracts.Passport;

namespace Employees.Application.Contracts.Employee;

public class EmployeeCreateRequest
{
    public string Name { get; set; }
    public string Surname { get; set; }
    
    [RegularExpression(@"^\+?[1-9][0-9]{7,14}$")]
    public string Phone { get; set; }
    
    public int CompanyId { get; set; }  
    public int DepartmentId { get; set; }
    public PassportCreateRequest Passport { get; set; }
}
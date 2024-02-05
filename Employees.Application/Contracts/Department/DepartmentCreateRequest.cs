using System.ComponentModel.DataAnnotations;

namespace Employees.Application.Contracts.Department;

public class DepartmentCreateRequest
{
    public string? Name { get; set; }
    
    [RegularExpression(@"^\+?[1-9][0-9]{7,14}$")]
    public string? Phone { get; set; }
}
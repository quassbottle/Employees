using System.ComponentModel.DataAnnotations;

namespace Employees.Application.Dto;

public class DepartmentUpdateRequest
{
    public string? Name { get; set; }
    
    [RegularExpression(@"^\+?[1-9][0-9]{7,14}$")]
    public string? Phone { get; set; }
}
using System.Text.Json.Serialization;

namespace Employees.Application.Dto;

public class EmployeeDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public int? CompanyId { get; set; }  
    public int? DepartmentId { get; set; }
    public PassportDto Passport { get; set; }
}
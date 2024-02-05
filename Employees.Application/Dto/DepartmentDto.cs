using System.Text.Json.Serialization;

namespace Employees.Application.Dto;

public class DepartmentDto
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
}
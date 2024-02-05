using System.Text.Json.Serialization;

namespace Employees.Application.Dto;

public class PassportDto
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Type { get; set; }
    public string Number { get; set; }
}
using System.Text.Json.Serialization;

namespace Employees.Domain.Entities;

public class Passport
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Number { get; set; }
}
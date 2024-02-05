using Employees.Domain.Exceptions.Shared;

namespace Employees.Domain.Exceptions.Employee;

public class EmployeeBadRequestException : BadRequestException
{
    public EmployeeBadRequestException(string message) : base(message)
    {
    }
}
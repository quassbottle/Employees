using Employees.Domain.Exceptions.Shared;

namespace Employees.Domain.Exceptions.Employee;

public sealed class EmployeeBadRequestException : BadRequestException
{
    public EmployeeBadRequestException(string message) : base(message)
    {
    }
}
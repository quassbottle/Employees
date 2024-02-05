using Employees.Domain.Exceptions.Shared;

namespace Employees.Domain.Exceptions.Employee;

public class EmployeeNotFoundException : NotFoundException
{
    public EmployeeNotFoundException(string message) : base(message)
    {
    }
}
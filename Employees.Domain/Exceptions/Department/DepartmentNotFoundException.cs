using Employees.Domain.Exceptions.Shared;

namespace Employees.Domain.Exceptions.Department;

public class DepartmentNotFoundException : NotFoundException
{
    public DepartmentNotFoundException(string message) : base(message)
    {
    }
}
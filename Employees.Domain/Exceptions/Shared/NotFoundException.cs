namespace Employees.Domain.Exceptions.Shared;

public class NotFoundException : Exception
{
    protected NotFoundException(string message) : base(message)
    {
    }
}
namespace Employees.Domain.Exceptions.Shared;

public class BadRequestException : Exception
{
    protected BadRequestException(string message) : base(message)
    {
    }
}
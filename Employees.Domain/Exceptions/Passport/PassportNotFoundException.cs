using Employees.Domain.Exceptions.Shared;

namespace Employees.Domain.Exceptions.Passport;

public class PassportNotFoundException : NotFoundException
{
    public PassportNotFoundException(string message) : base(message)
    {
    }
}
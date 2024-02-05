using Employees.Domain.Exceptions.Shared;

namespace Employees.Domain.Exceptions.Passport;

public class PassportBadRequestException : BadRequestException
{
    public PassportBadRequestException(string message) : base(message)
    {
    }
}
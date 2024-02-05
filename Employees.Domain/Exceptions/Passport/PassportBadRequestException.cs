using Employees.Domain.Exceptions.Shared;

namespace Employees.Domain.Exceptions.Passport;

public sealed class PassportBadRequestException : BadRequestException
{
    public PassportBadRequestException(string message) : base(message)
    {
    }
}
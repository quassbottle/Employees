using Employees.Domain.Entities;

namespace Employees.Domain.Repositories;

public interface IPassportRepository 
{
    Task<Passport> GetByIdAsync(int id);
    Task DeleteByIdAsync(int id);
    Task<int> CreateAsync(Passport passport);
    Task<bool> ExistsByNumberAsync(string number);
    Task UpdateAsync(Passport passport, int id);
}
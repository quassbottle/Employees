using Employees.Domain.Entities;

namespace Employees.Domain.Repositories;

public interface IPassportRepository 
{
    Task<Passport> GetByIdAsync(int id);
    Task DeleteByIdAsync(int id);
    Task<int> CreateAsync(Passport passport);
    Task<bool> ExistsByNumberAndTypeAsync(string number, string type);
    Task UpdateAsync(Passport passport, int id);
}
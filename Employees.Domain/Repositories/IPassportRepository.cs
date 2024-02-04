using Employees.Domain.Entities;

namespace Employees.Domain.Repositories;

public interface IPassportRepository 
{
    public Task<Passport> GetByIdAsync(int id);
    public Task DeleteByIdAsync(int id);
    public Task<int> CreateAsync(Passport passport);
    public Task<bool> ExistsAsync(int id);
    public Task UpdateAsync(Passport passport, int id);
    public Task<IList<Passport>> GetAllAsync();
}
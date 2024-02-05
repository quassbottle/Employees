using Employees.Application.Dto;

namespace Employees.Application.Services.Interfaces;

public interface IPassportService
{
    public Task<int> CreateAsync(PassportDto passportDto);
    public Task<PassportDto> GetByIdAsync(int id);
    public Task UpdateAsync(PassportDto passportDto, int id);
    public Task DeleteAsync(int id);
    public Task<IList<PassportDto>> GetAllAsync();
}
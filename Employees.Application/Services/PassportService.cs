using Employees.Application.Dto;
using Employees.Application.Services.Interfaces;
using Employees.Domain.Entities;
using Employees.Domain.Exceptions.Department;
using Employees.Domain.Exceptions.Passport;
using Employees.Domain.Repositories;

namespace Employees.Application.Services;

public class PassportService : IPassportService
{
    private readonly IPassportRepository _repository;

    public PassportService(IPassportRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<int> CreateAsync(PassportDto passportDto)
    {
        return await _repository.CreateAsync(new Passport
        {
            Type = passportDto.Type,
            Number = passportDto.Number,
        });
    }

    public async Task<PassportDto> GetByIdAsync(int id)
    {
        var candidate = await _repository.GetByIdAsync(id);

        if (candidate is null)
        {
            throw new PassportNotFoundException("Passport with such id has not been found");
        }

        return new PassportDto
        {
            Id = candidate.Id,
            Type = candidate.Type,
            Number = candidate.Number,
        };
    }

    public async Task UpdateAsync(PassportDto passportDto, int id)
    {
        if (!await _repository.ExistsAsync(id))
        {
            throw new PassportNotFoundException("Department with such id has not been found");
        }
        
        await _repository.UpdateAsync(new Passport
        {
            Type = passportDto.Type,
            Number = passportDto.Number
        }, id);
    }

    public async Task DeleteAsync(int id)
    {
        if (!await _repository.ExistsAsync(id))
        {
            throw new PassportNotFoundException("Passport with such id has not been found");
        }

        await _repository.DeleteByIdAsync(id);
    }

    public async Task<IList<PassportDto>> GetAllAsync()
    {
        var result = await _repository.GetAllAsync();
        
        return result.Select(passport => new PassportDto
        {
            Id = passport.Id,
            Type = passport.Type,
            Number = passport.Number,
        }).ToList();
    }
}
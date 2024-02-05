using Employees.Application.Dto;
using Employees.Application.Services.Interfaces;
using Employees.Domain.Entities;
using Employees.Domain.Exceptions.Department;
using Employees.Domain.Repositories;

namespace Employees.Application.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _repository;

    public DepartmentService(IDepartmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> CreateAsync(DepartmentDto departmentDto)
    {
        return await _repository.CreateAsync(new Department
        {
            Name = departmentDto.Name,
            Phone = departmentDto.Phone,
        });
    }

    public async Task<DepartmentDto> GetByIdAsync(int id)
    {
        var candidate = await _repository.GetByIdAsync(id);

        if (candidate is null)
        {
            throw new DepartmentNotFoundException("Department with such id has not been found");
        }

        return new DepartmentDto
        {
            Id = candidate.Id,
            Name = candidate.Name,
            Phone = candidate.Phone,
        };
    }

    public async Task UpdateAsync(DepartmentDto departmentDto, int id)
    {
        if (!await _repository.ExistsAsync(id))
        {
            throw new DepartmentNotFoundException("Department with such id has not been found");
        }
        
        await _repository.UpdateAsync(new Department
        {
            Name = departmentDto.Name,
            Phone = departmentDto.Phone
        }, id);
    }

    public async Task DeleteAsync(int id)
    {
        if (!await _repository.ExistsAsync(id))
        {
            throw new DepartmentNotFoundException("Department with such id has not been found");
        }

        await _repository.DeleteByIdAsync(id);
    }

    public async Task<IList<DepartmentDto>> GetAllAsync()
    {
        var result = await _repository.GetAllAsync();
        
        return result.Select(department => new DepartmentDto
        {
            Id = department.Id,
            Name = department.Name,
            Phone = department.Phone,
        }).ToList();
    }
}
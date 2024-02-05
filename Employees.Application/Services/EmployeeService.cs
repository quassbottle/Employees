using Employees.Application.Dto;
using Employees.Application.Services.Interfaces;
using Employees.Domain.Entities;
using Employees.Domain.Exceptions.Department;
using Employees.Domain.Exceptions.Employee;
using Employees.Domain.Repositories;

namespace Employees.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IPassportRepository _passportRepository;
    private readonly IDepartmentRepository _departmentRepository;

    public EmployeeService(IEmployeeRepository employeeRepository, IPassportRepository passportRepository, IDepartmentRepository departmentRepository)
    {
        _employeeRepository = employeeRepository;
        _passportRepository = passportRepository;
        _departmentRepository = departmentRepository;
    }
    
    public async Task<int> CreateAsync(EmployeeDto employeeDto)
    {
        var passportId = await _passportRepository.CreateAsync(new Passport
        {
            Type = employeeDto.Passport.Type,
            Number = employeeDto.Passport.Number,
        });

        var departmentId = await _departmentRepository.CreateAsync(new Department
        {
            Name = employeeDto.Department.Name,
            Phone = employeeDto.Department.Phone,
        });
        
        return await _employeeRepository.CreateAsync(new Employee
        {
           Name = employeeDto.Name,
           Surname = employeeDto.Surname,
           CompanyId = employeeDto.CompanyId,
           DepartmentId = departmentId,
           PassportId = passportId,
           Phone = employeeDto.Phone
        });
    }

    public async Task<EmployeeDto> GetByIdAsync(int id)
    {
        var candidate = await _employeeRepository.GetByIdAsync(id);

        if (candidate is null)
        {
            throw new EmployeeNotFoundException("Employee with such id has not been found");
        }

        var department = await _departmentRepository.GetByIdAsync(candidate.DepartmentId);
        var passport = await _passportRepository.GetByIdAsync(candidate.PassportId);

        return new EmployeeDto
        {
            Id = candidate.Id,
            Name = candidate.Name,
            Surname = candidate.Surname,
            Phone = candidate.Phone,
            CompanyId = candidate.CompanyId,
            Department = new DepartmentDto
            {
                Id = department.Id,
                Phone = department.Phone,
                Name = department.Name,
            },
            Passport = new PassportDto
            {
                Id = passport.Id,
                Type = passport.Type,
                Number = passport.Number,
            },
        };
    }

    public async Task UpdateAsync(EmployeeDto employeeDto, int id)
    {
        var db = await _employeeRepository.GetByIdAsync(id);
        
        if (db is null)
        {
            throw new EmployeeNotFoundException("Employee with such id has not been found");
        }

        if (employeeDto.Department is not null)
        {
            await _departmentRepository.UpdateAsync(new Department
            {
                Name = employeeDto.Department.Name,
                Phone = employeeDto.Department.Phone,
            }, db.DepartmentId);
        }

        if (employeeDto.Passport is not null)
        {
            await _passportRepository.UpdateAsync(new Passport
            {
                Type = employeeDto.Passport.Type,
                Number = employeeDto.Passport.Number,
            }, db.PassportId);
        }

        await _employeeRepository.UpdateAsync(new Employee
        {
            Name = employeeDto.Name,
            Phone = employeeDto.Phone,
            Surname = employeeDto.Surname,
            CompanyId = employeeDto.CompanyId,
            PassportId = db.PassportId,
            DepartmentId = db.DepartmentId,
        }, id);
    }

    public async Task DeleteAsync(int id)
    {
        var db = await _employeeRepository.GetByIdAsync(id);
        
        if (db is null)
        {
            throw new EmployeeNotFoundException("Employee with such id has not been found");
        }

        await _employeeRepository.DeleteByIdAsync(id);
        await _passportRepository.DeleteByIdAsync(db.PassportId);
        await _departmentRepository.DeleteByIdAsync(db.DepartmentId);
    }
    
    public Task<IList<EmployeeDto>> GetAllByCompanyIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<EmployeeDto>> GetAllByDepartmentIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
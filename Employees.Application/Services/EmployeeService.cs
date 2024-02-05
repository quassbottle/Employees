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

        if (employeeDto.DepartmentId is not null &&
            !await _departmentRepository.ExistsAsync(employeeDto.DepartmentId.Value))
        {
            throw new DepartmentNotFoundException("Department with such id has not been found");
        }
        
        return await _employeeRepository.CreateAsync(new Employee
        {
           Name = employeeDto.Name,
           Surname = employeeDto.Surname,
           CompanyId = employeeDto.CompanyId,
           DepartmentId = employeeDto.DepartmentId.Value,
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

        var passport = await _passportRepository.GetByIdAsync(candidate.PassportId);

        return new EmployeeDto
        {
            Id = candidate.Id,
            Name = candidate.Name,
            Surname = candidate.Surname,
            Phone = candidate.Phone,
            CompanyId = candidate.CompanyId,
            DepartmentId = candidate.DepartmentId,
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
            DepartmentId = employeeDto.DepartmentId ?? db.DepartmentId,
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
    }
    
    public async Task<IList<EmployeeDto>> GetAllByCompanyIdAsync(int id)
    {
        var query = await _employeeRepository.GetAllByCompanyIdAsync(id);

        return query.Select(async (employee) =>
        {
            var passport = await _passportRepository.GetByIdAsync(employee.PassportId);
            return new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                CompanyId = employee.CompanyId,
                DepartmentId = employee.DepartmentId,
                Phone = employee.Phone,
                Passport = new PassportDto
                {
                    Id = passport.Id,
                    Number = passport.Number,
                    Type = passport.Type,
                },
            };
        }).Select(t => t.Result).ToList();
    }

    public async Task<IList<EmployeeDto>> GetAllByDepartmentIdAsync(int id)
    {
        var query = await _employeeRepository.GetAllByDepartmentIdAsync(id);
        
        return query.Select(async (employee) =>
        {
            var passport = await _passportRepository.GetByIdAsync(employee.PassportId);
            return new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                CompanyId = employee.CompanyId,
                DepartmentId = employee.DepartmentId,
                Phone = employee.Phone,
                Passport = new PassportDto
                {
                    Id = passport.Id,
                    Number = passport.Number,
                    Type = passport.Type,
                },
            };
        }).Select(t => t.Result).ToList();
    }
}
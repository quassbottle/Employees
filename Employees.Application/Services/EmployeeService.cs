using Employees.Application.Dto;
using Employees.Application.Services.Interfaces;
using Employees.Domain.Entities;
using Employees.Domain.Exceptions.Department;
using Employees.Domain.Exceptions.Employee;
using Employees.Domain.Exceptions.Passport;
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
        if (employeeDto.DepartmentId is not null &&
            !await _departmentRepository.ExistsAsync(employeeDto.DepartmentId.Value))
        {
            throw new DepartmentNotFoundException("Department with such id has not been found");
        }

        if (await _passportRepository.ExistsByNumberAsync(employeeDto.Passport.Number))
        {
            throw new PassportBadRequestException("Passport with such number already exists");
        }

        var passportId = await _passportRepository.CreateAsync(new Passport
        {
            Type = employeeDto.Passport.Type,
            Number = employeeDto.Passport.Number,
        });

        try
        {
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
        catch
        {
            await _passportRepository.DeleteByIdAsync(passportId);
            throw new EmployeeBadRequestException("Bad parameters");
        }
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
        var dbEmployee = await _employeeRepository.GetByIdAsync(id);
        
        if (dbEmployee is null)
        {
            throw new EmployeeNotFoundException("Employee with such id has not been found");
        }
        
        if (employeeDto.DepartmentId is not null &&
            !await _departmentRepository.ExistsAsync(employeeDto.DepartmentId.Value))
        {
            throw new DepartmentNotFoundException("Department with such id does not exist");
        }
        
        if (employeeDto.Passport is not null)
        {
            if (await _passportRepository.ExistsByNumberAsync(employeeDto.Passport.Number))
            {
                throw new PassportBadRequestException("Passport with such number already exists");
            }
            
            await _passportRepository.UpdateAsync(new Passport
            {
                Type = employeeDto.Passport.Type,
                Number = employeeDto.Passport.Number,
            }, dbEmployee.PassportId);
        }

        await _employeeRepository.UpdateAsync(new Employee
        {
            Name = employeeDto.Name,
            Phone = employeeDto.Phone,
            Surname = employeeDto.Surname,
            CompanyId = employeeDto.CompanyId,
            PassportId = dbEmployee.PassportId,
            DepartmentId = employeeDto.DepartmentId ?? dbEmployee.DepartmentId,
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
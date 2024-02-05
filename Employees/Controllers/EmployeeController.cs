using System.Reflection.Metadata;
using Employees.Application.Contracts.Employee;
using Employees.Application.Contracts.Shared;
using Employees.Application.Dto;
using Employees.Application.Services.Interfaces;
using Employees.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeService;
    private readonly IDepartmentService _departmentService;

    public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
    {
        _employeeService = employeeService;
        _departmentService = departmentService;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(int id)
    {
        await _employeeService.DeleteAsync(id);
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var candidate = await _employeeService.GetByIdAsync(id);

        var department = await _departmentService.GetByIdAsync(candidate.DepartmentId!.Value);
        
        return Ok(new EmployeeModel
        {
            Id = candidate.Id,
            Name = candidate.Name,
            Surname = candidate.Surname,
            Phone = candidate.Phone,
            CompanyId = candidate.CompanyId!.Value,
            Passport = new PassportModel
            {
                Number = candidate.Passport.Number,
                Type = candidate.Passport.Type,
            },
            Department = new DepartmentModel
            {
                Id = department.Id,
                Name = department.Name,
                Phone = department.Phone,
            },
        });
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(EmployeeUpdateRequest dto, int id)
    {
        if (dto.Phone is null && dto.Name is null && dto.Surname is null && dto.CompanyId is null &&
            dto.DepartmentId is null && dto.Passport is null)
        {
            return BadRequest(new ExceptionResponse
            {
                Status = 400,
                Message = "Bad parameters",
            });
        }

        var passport = new PassportDto();
        if (dto.Passport is not null)
        {
            passport = new PassportDto
            {
                Number = dto.Passport.Number,
                Type = dto.Passport.Type,
            };
        }
        
        await _employeeService.UpdateAsync(new EmployeeDto
        {
            Name = dto.Name,
            Surname = dto.Surname,
            Phone = dto.Phone,
            Passport = passport,
            CompanyId = dto.CompanyId,
            DepartmentId = dto.DepartmentId,
        }, id);
        
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Create(EmployeeCreateRequest dto)
    {
        return Ok(await _employeeService.CreateAsync(new EmployeeDto
        {
            Name = dto.Name,
            CompanyId = dto.CompanyId,
            Phone = dto.Phone,
            Surname = dto.Surname,
            DepartmentId = dto.DepartmentId,
            Passport = new PassportDto
            {
                Number = dto.Passport.Number,
                Type = dto.Passport.Type,
            }
        }));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int? departmentId, [FromQuery] int? companyId)
    {
        if (departmentId is not null)
        {
            return await GetAllByDepartmentId(departmentId.Value);
        }
        if (companyId is not null)
        {
            return await GetAllByCompanyId(companyId.Value);
        }
        
        return BadRequest(new ExceptionResponse
        {
            Status = 400,
            Message = "Bad parameters",
        });
    }

    private async Task<IActionResult> GetAllByCompanyId(int companyId)
    { 
        var response = await _employeeService.GetAllByCompanyIdAsync(companyId);

        return Ok(response.Select(async (employee) =>
        {
            var department = await _departmentService.GetByIdAsync(employee.DepartmentId!.Value);
            return new EmployeeModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                Phone = employee.Phone,
                CompanyId = employee.CompanyId!.Value,
                Passport = new PassportModel
                {
                    Number = employee.Passport.Number,
                    Type = employee.Passport.Type,
                },
                Department = new DepartmentModel
                {
                    Id = department.Id,
                    Name = department.Name,
                    Phone = department.Phone,
                },
            };
        }).Select(t => t.Result));   
    }

    private async Task<IActionResult> GetAllByDepartmentId(int departmentId)
    {
        var response = await _employeeService.GetAllByDepartmentIdAsync(departmentId);

        return Ok(response.Select(async (employee) =>
        {
            var department = await _departmentService.GetByIdAsync(employee.DepartmentId!.Value);
            return new EmployeeModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                Phone = employee.Phone,
                CompanyId = employee.CompanyId!.Value,
                Passport = new PassportModel
                {
                    Number = employee.Passport.Number,
                    Type = employee.Passport.Type,
                },
                Department = new DepartmentModel
                {
                    Id = department.Id,
                    Name = department.Name,
                    Phone = department.Phone,
                },
            };
        }).Select(t => t.Result));
    }
}
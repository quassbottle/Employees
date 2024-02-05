using System.Reflection.Metadata;
using Employees.Application.Contracts.Employee;
using Employees.Application.Contracts.Shared;
using Employees.Application.Dto;
using Employees.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class EmployeeController : Controller
{
    private readonly IEmployeeService _service;

    public EmployeeController(IEmployeeService service)
    {
        _service = service;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(int id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(EmployeeUpdateRequest dto, int id)
    {
        if (dto.Phone is null && dto.Name is null && dto.Surname is null && dto.CompanyId is null &&
            dto.Department is null && dto.Passport is null)
        {
            return BadRequest(new ExceptionResponse
            {
                Status = 400,
                Message = "Bad parameters",
            });
        }

        var department = new DepartmentDto();
        if (dto.Department is not null)
        {
            department = new DepartmentDto
            {
                Name = dto.Department.Name,
                Phone = dto.Department.Phone,
            };
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
        
        await _service.UpdateAsync(new EmployeeDto
        {
            Name = dto.Name,
            Surname = dto.Surname,
            Phone = dto.Phone,
            Passport = passport,
            CompanyId = dto.CompanyId,
            Department = department,
        }, id);
        
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Create(EmployeeCreateRequest dto)
    {
        return Ok(await _service.CreateAsync(new EmployeeDto
        {
            Name = dto.Name,
            CompanyId = dto.CompanyId,
            Phone = dto.Phone,
            Surname = dto.Surname,
            Department = new DepartmentDto
            {
                Name = dto.Department.Name,
                Phone = dto.Department.Phone,
            },
            Passport = new PassportDto
            {
                Number = dto.Passport.Number,
                Type = dto.Passport.Type,
            }
        }));
    }
}
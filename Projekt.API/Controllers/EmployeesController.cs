using AvanceradDOTNET_Projekt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt.API.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IEmployee _employees;
        public EmployeesController(IEmployee employees)
        {
            _employees = employees;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllEmployees()
        {
            try
            {
                return Ok(await _employees.GetAllAsync());               
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error connecting to database!");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var result = await _employees.GetSingleAsync(id);
                if(result != null)
                {
                    return Ok(result);
                }
                return NotFound($"Employee with id: {id} was not found in database!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error connecting to database!");
            }
        }

        [HttpGet]
        [Route("{id}/timereports")]
        public async Task<ActionResult> GetTimeReportsByEmployee(int id)
        {
            try
            {
                var inDb = await GetEmployee(id);
                if(inDb != null)
                {
                    var result = await _employees.GetTimeReportsByEmployeeAsync(id);
                    if (result != null && result.Any())
                    {
                        return Ok(result);
                    }
                }
                return NotFound($"Employee with id: {id} was not found in database!");
                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error connecting to database!");
            }
        }
        [HttpGet]
        [Route("{id}/week")]
        public async Task<ActionResult<int>> GetHoursWorkedByWeek(int id, int week)
        {
            try
            {
                if(week >= 1 && week <= 52)
                {
                    var inDb = await GetEmployee(id);
                    if (inDb != null)
                    {
                        return Ok(await _employees.HoursWorkedByWeekAsync(id, week));
                    }
                    return NotFound($"Employee with id: {id} was not found in database!");
                }
                return BadRequest($"{week} is not a valis weeknumber! Enter a number between 1 and 52!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error connecting to database!");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            try
            {
                if(employee == null)
                {
                    var result = await _employees.AddAsync(employee);
                    return CreatedAtAction(nameof(GetEmployee), new { id = result.Id }, result);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error connecting to database!");
            }
        }
    }
}

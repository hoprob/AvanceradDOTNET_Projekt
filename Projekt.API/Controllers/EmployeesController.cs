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
                var inDb = await _employees.GetSingleAsync(id);
                if(inDb != null)
                {
                    var result = await _employees.GetTimeReportsByEmployeeAsync(id);
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
        [Route("{id}/hoursworked")]
        public async Task<ActionResult<int>> GetHoursWorkedByWeek(int id, int year, int week)
        {
            try
            {
                if(week >= 1 && week <= 52)
                {
                    var inDb = await _employees.GetSingleAsync(id);
                    if (inDb != null)
                    {
                        return Ok(await _employees.HoursWorkedByWeekAsync(id, year, week));
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
                if(employee != null)
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
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                if(id == employee.Id)
                {
                    var result = await _employees.UpdateAsync(employee);
                    if(result != null)
                    {
                        return Ok(result);
                    }
                    return NotFound($"Employee with id: {id} was not found in database!");
                }
                return BadRequest("The id:s in URL and body does not match!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error connecting to database!");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var result = await _employees.DeleteAsync(id);
                if(result != null)
                {
                    return NoContent();
                }
                return NotFound($"Employee with id: {id} was not found in database!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error connecting to database!");
            }
        }
    }
}

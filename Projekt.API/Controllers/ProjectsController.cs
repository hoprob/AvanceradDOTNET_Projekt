using AvanceradDOTNET_Projekt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        IProject _projects;
        public ProjectsController(IProject projects)
        {
            _projects = projects;
        }
        [HttpGet]
        [Route("{id}/employees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesInProject(int id)
        {
            try
            {
                var inDb = await _projects.GetSingleAsync(id);
                if(inDb != null)
                {
                    var result = await _projects.GetEmployeesInProjectAsync(id);
                    if (result != null && result.Any())
                    {
                        return Ok(result);
                    }
                    return NotFound($"No employees found in project with id: {id}");
                }
                return NotFound($"No project with id: {id} found in database!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error connecting to database!");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            try
            {
                var result = await _projects.GetSingleAsync(id);
                if(result == null)
                {
                    return NotFound($"No project with id: {id} found in database!");
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error connecting to database!");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Project>> AddProject(Project newProject)
        {
            try
            {
                if(newProject == null)
                {
                    return BadRequest();
                }
                var result = await _projects.AddAsync(newProject);
                return CreatedAtAction(nameof(GetProject), new {id = result.Id}, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding project to database!");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Project>> UpdateProject(int id, Project project)
        {
            try
            {
                if (id == project.Id)
                {
                    var result = await _projects.UpdateAsync(project);
                    if (result != null)
                    {
                        return result;
                    }
                    return NotFound($"No project with id: {id} found in database!");
                }
                return BadRequest("The id:s doeos not match!");
            }catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error connecting to database!");
            }          
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteProject(int id)
        {
            try
            {
                var result = await _projects.DeleteAsync(id);
                if(result != null)
                {
                    return NoContent();
                }
                return NotFound($"No project with id: {id} found in database!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error connecting to database!");
            }
        }
    }
}

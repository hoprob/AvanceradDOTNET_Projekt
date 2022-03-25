using AvanceradDOTNET_Projekt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt.API.Services;

namespace Projekt.API.Controllers
{
    //TODO Get all employees of a project
    //TODO Add Project
    //TODO Update Project
    //TODO Delete Project
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        IRestAPI<Project> _projects;
        public ProjectsController(IRestAPI<Project> projects)
        {
            _projects = projects;
        }
    }
}

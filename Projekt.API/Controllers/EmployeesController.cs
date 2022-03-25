using AvanceradDOTNET_Projekt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt.API.Services;

namespace Projekt.API.Controllers
{
    //TODO Getall employees
    //TODO Get single employee with timereports
    //TODO Get hours worked in a week for specific employee
    //TODO Add employee
    //TODO Update Employee
    //TODO Delete Employee
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IRestAPI<Employee> _employees;
        public EmployeesController(IRestAPI<Employee> employees)
        {
            _employees = employees;
        }
    }
}

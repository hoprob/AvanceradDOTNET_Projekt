using AvanceradDOTNET_Projekt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt.API.Services;

namespace Projekt.API.Controllers
{
    //TODO Add TimeReport
    //TODO Update TimeReport
    //TODO Delete TimeReport
    [Route("api/[controller]")]
    [ApiController]
    public class TimeReportsController : ControllerBase
    {
        IRestAPI<TimeReport> _timeReports;
        public TimeReportsController(IRestAPI<TimeReport> timeReports)
        {
            _timeReports = timeReports;
        }
    }
}

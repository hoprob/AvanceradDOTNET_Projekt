using AutoMapper;
using AvanceradDOTNET_Projekt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekt.API.DataTransferObjects;
using Projekt.API.Services;
using System;
using System.Threading.Tasks;

namespace Projekt.API.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class TimeReportsController : ControllerBase
    {
        IRestAPI<TimeReport> _timeReports;
        IMapper _mapper;
        public TimeReportsController(IRestAPI<TimeReport> timeReports, IMapper mapper)
        {
            _timeReports = timeReports;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeReport>> GetTimeReport(int id)
        {
            try
            {
                var result = await _timeReports.GetSingleAsync(id);
                if(result == null)
                {
                    return NotFound($"Timereport with id: {id} was not found in databse!");
                }
                var timeReportDTO = _mapper.Map<TimeReportDTO>(result);
                return Ok(timeReportDTO);
            }catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error connecting to database!");
            }
        }
        [HttpPost]
        public async Task<ActionResult<TimeReport>> AddTimeReport(TimeReport timeReport)
        {
            try
            {
                if(timeReport == null)
                {
                    return BadRequest();
                }
                var newTimeReport = await _timeReports.AddAsync(timeReport);
                return CreatedAtAction(nameof(GetTimeReport),
                    new { id = newTimeReport.Id }, newTimeReport);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while adding data to database!");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TimeReport>> UpdateTimeReport(int id,
            TimeReport timeReport)
        {
            try
            {
                if (id == timeReport.Id)
                {
                    var result = await _timeReports.UpdateAsync(timeReport);
                    if (result != null)
                    {
                        return result;
                    }
                    return NotFound($"Timereport with id: {id} is not found in database!");
                }
                return BadRequest("The id:s doeos not match!");
            }catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error connecting to database!");
            }           
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TimeReport>> DeleteTimeReport(int id)
        {
            try
            {
                var inDb = await _timeReports.GetSingleAsync(id);
                if(inDb == null)
                {
                    return NotFound($"Timereport with id: {id} was not found in database!");
                }
                var result = await _timeReports.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error connecting to database!");
            }
        }
    }
}

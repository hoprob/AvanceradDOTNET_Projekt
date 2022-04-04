using AutoMapper;
using AvanceradDOTNET_Projekt.Models;
using Projekt.API.DataTransferObjects;

namespace Projekt.API.Profiles
{
    public class ProjectProfiles : Profile 
    {
        public ProjectProfiles()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<Employee, EmployeeTimeReportsDTO>();
            CreateMap<TimeReport, SingleEmpTimeReportDTO>();
            CreateMap<TimeReport, TimeReportDTO>();
            CreateMap<Project, ProjectDTO>();
        }
    }
}

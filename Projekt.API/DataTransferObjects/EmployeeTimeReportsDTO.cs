
using System.Collections.Generic;

namespace Projekt.API.DataTransferObjects
{
    public class EmployeeTimeReportsDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<SingleEmpTimeReportDTO> TimeReports { get; set; }
    }
}

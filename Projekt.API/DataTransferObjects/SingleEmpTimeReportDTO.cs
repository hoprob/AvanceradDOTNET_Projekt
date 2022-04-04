using System;

namespace Projekt.API.DataTransferObjects
{
    public class SingleEmpTimeReportDTO
    {
        public DateTime Date { get; set; }
        public int Week { get; set; }
        public double HoursWorked { get; set; }
        public int ProjectId { get; set; }
    }
}

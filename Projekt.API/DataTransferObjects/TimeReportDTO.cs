using System;

namespace Projekt.API.DataTransferObjects
{
    public class TimeReportDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Week { get; set; }
        public double HoursWorked { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
    }
}

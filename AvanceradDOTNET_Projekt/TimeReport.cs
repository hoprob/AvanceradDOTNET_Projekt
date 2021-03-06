using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.Json.Serialization;

namespace AvanceradDOTNET_Projekt.Models
{
    public class TimeReport
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        //Returns the weeknumber of Date.
        public int Week { get => CultureInfo.InvariantCulture.Calendar.
                GetWeekOfYear(Date, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);}
        [Required]
        [Range(0, 24, ErrorMessage = "Worked hours must be in range 0-24!")]
        public double HoursWorked { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [JsonIgnore]
        public Employee Employee { get; set; }
        [Required]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}

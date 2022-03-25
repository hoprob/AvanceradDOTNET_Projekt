using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

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
        public double HoursWorked { get; set; }
        [Required]
        public Employee Employee { get; set; }
        [Required]
        public Project Project { get; set; }
    }
}

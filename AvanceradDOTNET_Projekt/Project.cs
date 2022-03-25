using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AvanceradDOTNET_Projekt.Models
{
    public  class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProjectName { get; set; }
#nullable enable
        public string? ProjectNumber { get; set; }
#nullable disable
        public List<TimeReport> TimeReports { get; set; }
    }
}

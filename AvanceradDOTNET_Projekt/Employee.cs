
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace AvanceradDOTNET_Projekt.Models
{
    public  class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Firstname must be min. 2 and max. 25 characters!")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Lastname must be min. 2 and max. 25 characters!")]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        public List<TimeReport> TimeReports { get; set; }
    }
}

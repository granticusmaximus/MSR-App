using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class EmployeeVM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpID { get; set; }
        [ForeignKey("Analyst")]
        public int AssignedBA { get; set; }
        public Analyst Analyst { get; set; }

        [ForeignKey("Developer")]
        public int AssignedDev { get; set; }
        public Developer Developer { get; set; }
    }
}

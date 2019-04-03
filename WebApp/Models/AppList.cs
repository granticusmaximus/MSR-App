using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class AppList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppID { get; set; }
        [DisplayName("Application Name:")]
        public string AppName { get; set; }
        [DisplayName("Purpose:")]
        public string AppNotes { get; set; }

        [ForeignKey("Analyst")]
        [DisplayName("BA Assigned:")]
        public int AssignedBA { get; set; }
        public Analyst Analyst { get; set; }

        [ForeignKey("Developer")]
        [DisplayName("Dev Assigned:")]
        public int AssignedDev { get; set; }
        public Developer Developer { get; set; }
    }
}

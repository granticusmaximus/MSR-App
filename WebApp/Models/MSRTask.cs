using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class MSRTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MsrID { get; set; }

        public string Employee { get; set; }

        public string AppTitle { get; set; }

        [DisplayName("Task Number/MSR Title:")]
        public string MSRtitle { get; set; }

        [DisplayName("Date Completed:")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        [DisplayName("Notes:")]
        public string MSRNote { get; set; }


    }
}

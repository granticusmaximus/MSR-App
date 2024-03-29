﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpID { get; set; }
        [DisplayName("First Name:")]
        public string FName { get; set; }
        [DisplayName("Last Name:")]
        public string LName { get; set; }
        [DisplayName("Email:")]
        public string Email { get; set; }
        [DisplayName("Phone:")]
        public string Phone { get; set; }
        [DisplayName("Name:")]
        public string Fullname
        {
            get { return FName + " " + LName; }
        }
    }
}

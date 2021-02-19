﻿using MVC6WebApi.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC6WebApi.Models
{
    public class Student
    {
        [Key]
        public int Sid { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }

        public string Email { get; set; }

        public int Class { get; set; }

        public string SchoolName { get; set; }

        public string City { get; set; }

        [Required(ErrorMessage = "Please choose admission date")]
        [Display(Name = "Admission Date")]
        [DataType(DataType.Date)]
        [CustomAdmDate(ErrorMessage = "Adm date cannot be greater than today's date")]
        public DateTime AdmissionDate { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [Min18Years]
        public DateTime DOB { get; set; }
    }
}

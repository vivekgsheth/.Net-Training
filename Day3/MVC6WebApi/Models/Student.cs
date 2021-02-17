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

        public string Name { get; set; }

        public string Email { get; set; }

        public int Class { get; set; }

        public string SchoolName { get; set; }

        public string City { get; set; }
    }
}

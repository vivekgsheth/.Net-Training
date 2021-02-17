using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC6WebApi.Models
{
    public class StudentDataContext : DbContext
    {
        public StudentDataContext(DbContextOptions<StudentDataContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}

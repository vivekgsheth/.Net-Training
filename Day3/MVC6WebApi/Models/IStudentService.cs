using System.Collections.Generic;

namespace MVC6WebApi.Models
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudents();
        Student GetOneStudent(int id);
    }
}
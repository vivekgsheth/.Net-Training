using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC6WebApi.Models;

namespace MVC6WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : ControllerBase
    {
        private readonly IStudentService _context;

        public StudentController(IStudentService context)
        {
            _context = context;
        }

        // GET: api/Student
        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            return _context.GetAllStudents();
        }

        //[HttpGet("champs")]   // localhost:8080/api/student/champs

        //[HttpGet]
        //[Route("~/champs")]    // localhost:8080/champs
        //public IEnumerable<Student> GetChamps()
        //{
        //    return _context.GetAllStudents();
        //}


        // GET: api/Student/5
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent([FromRoute]int id)
        {
            var student = _context.GetOneStudent(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/Student/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutStudent(int id, Student student)
        //{
        //    if (id != student.Sid)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(student).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StudentExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Student
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Student>> PostStudent(Student student)
        //{
        //    _context.Students.Add(student);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetStudent", new { id = student.Sid }, student);
        //}

        //// DELETE: api/Student/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Student>> DeleteStudent(int id)
        //{
        //    var student = await _context.Students.FindAsync(id);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Students.Remove(student);
        //    await _context.SaveChangesAsync();

        //    return student;
        //}

        //private bool StudentExists(int id)
        //{
        //    return _context.Students.Any(e => e.Sid == id);
        //}
    }
}

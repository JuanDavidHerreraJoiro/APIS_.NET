using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using universityApiBackend.DataAccess;
using universityApiBackend.Models.DataModels;
using universityApiBackend.Services;

namespace universityApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly UniversityDBContext _context;

        //Services
        //private readonly ICoursesServices _coursesServices;
        private readonly IServices _services;

        public CoursesController(UniversityDBContext context, IServices services)
        {
            _context = context;
            _services = services;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await _context.Courses.Include(c => c.Chapters).ToListAsync();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }

        //Nuevos metodos

        [HttpGet("coursesForLevelWithStudents/{level}")]
        public ActionResult<IEnumerable<Course>> GetCoursesForLevelWithStudents(Level level)
        {
            var coursesForLevelWithStudentslList = _services.GetCoursesForLevelWithStudents(level).ToList();

            if (coursesForLevelWithStudentslList == null)
            {
                return NotFound();
            }

            return coursesForLevelWithStudentslList;
        }

        [HttpGet("coursesForLevelInCategory/{level}/{idCategory}")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCoursesForLevelInCategory(Level level, int idCategory)
        {

            var category = await _context.Categories.FindAsync(idCategory);

            var coursesForLevelInCategorylList = _services.GetCoursesForLevelInCategory(level, category).ToList();

            if (coursesForLevelInCategorylList == null)
            {
                return NotFound();
            }

            return coursesForLevelInCategorylList;
        }

        [HttpGet("coursesWithoutStudents")]
        public ActionResult<IEnumerable<Course>> GetCoursesWithoutStudents()
        {
            var coursesWithoutStudentslList = _services.GetCoursesWithoutStudents().ToList();

            if (coursesWithoutStudentslList == null)
            {
                return NotFound();
            }

            return coursesWithoutStudentslList;
        }
    }
}

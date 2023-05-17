using Microsoft.EntityFrameworkCore;
using universityApiBackend.DataAccess;
using universityApiBackend.Models.DataModels;

namespace universityApiBackend.Services
{
    public class StudentsServices : IStudentsServices
    {
        private readonly UniversityDBContext _context;

        public StudentsServices(UniversityDBContext context)
        {
            this._context = context;
        }

        // -> StudentService
        public IEnumerable<Student> GetAdultStudents()
            => _context.Students!.Where(student => (DateTime.Now.Year - student.Dob.Year) >= 18);

        public IEnumerable<Student> GetStudentsWithAtLeastOneCourse()
            => _context.Students!.Where(student => student.courses.Any());

        //Obtener todos los alumnos que no tienen cursos asociados
        public IEnumerable<Student> GetStudentsWithAtCourseNull() => _context.Students!.Where(a => !a.courses.Any()).ToList();

        //Obtener alumnos de un Curso concreto
        public IEnumerable<Student> GetStudentsByCourse(Course course)
            => _context.Students!.Where(student => student.courses.Contains(course));

    }
}

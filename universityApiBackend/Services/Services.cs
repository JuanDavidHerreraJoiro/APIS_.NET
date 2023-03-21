using universityApiBackend.DataAccess;
using universityApiBackend.Models.DataModels;

namespace universityApiBackend.Services
{
    public class Services : IServices
    {
        private readonly UniversityDBContext _context;

        public Services(UniversityDBContext context)
        {
            this._context = context;
        }

        // -> UserService
        public IEnumerable<User> GetUserByEmail(string email)
            => _context.Users!.Where(user => user.Email.Contains(email));


        // -> StudentService
        public IEnumerable<Student> GetAdultStudents()
            => _context.Students!.Where(student => (DateTime.Now.Year - student.Dob.Year) >= 18  );

        public IEnumerable<Student> GetStudentsWithAtLeastOneCourse()
            => _context.Students!.Where(student => student.courses.Any());

        // -> CourseService
        public IEnumerable<Course> GetCoursesForLevelWithStudents(Level level)
            => _context.Courses!.Where(course => course.Level == level && course.Students.Any());

        public IEnumerable<Course> GetCoursesForLevelInCategory(Level level, Category category)
            => _context.Courses!.Where(course => course.Level == level && course.Categories.Contains(category));

        public IEnumerable<Course> GetCoursesWithoutStudents()
            => _context.Courses!.Where(course => !course.Students.Any());
    }
}

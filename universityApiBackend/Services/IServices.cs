using universityApiBackend.Models.DataModels;

namespace universityApiBackend.Services
{
    public interface IServices
    {
        // -> IUserService
        public IEnumerable<User> GetUserByEmail(string email);

        // -> IStudentService
        public IEnumerable<Student> GetAdultStudents();
        public IEnumerable<Student> GetStudentsWithAtLeastOneCourse();

        // -> ICourseService
        public IEnumerable<Course> GetCoursesForLevelWithStudents(Level level);
        public IEnumerable<Course> GetCoursesForLevelInCategory(Level level, Category category);
        public IEnumerable<Course> GetCoursesWithoutStudents();
    }
}

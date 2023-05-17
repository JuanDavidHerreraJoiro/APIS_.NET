using universityApiBackend.Models.DataModels;

namespace universityApiBackend.Services
{
    public interface IStudentsServices
    {
        // -> IStudentService
        public IEnumerable<Student> GetAdultStudents();
        public IEnumerable<Student> GetStudentsWithAtLeastOneCourse();
        public IEnumerable<Student> GetStudentsWithAtCourseNull();
        public IEnumerable<Student> GetStudentsByCourse(Course course);
    }
}

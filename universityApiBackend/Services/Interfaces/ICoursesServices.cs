using MessagePack;
using Microsoft.AspNetCore.Mvc;
using universityApiBackend.Models.DataModels;

namespace universityApiBackend.Services
{
    public interface ICoursesServices
    {
        // -> ICourseService
        public IEnumerable<Course> GetCoursesForLevelWithStudents(Level level);
        public IEnumerable<Course> GetCoursesForLevelInCategory(Level level, Category category);
        public IEnumerable<Course> GetCoursesWithoutStudents();
        public IEnumerable<Course> GetCoursesByCategory(Category category);
        public IEnumerable<Course> GetCoursesWithAtChaptersNull();
        public IEnumerable<Course> GetCoursesByStudent(Student student);
    }
}

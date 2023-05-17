using Microsoft.EntityFrameworkCore;
using universityApiBackend.DataAccess;
using universityApiBackend.Models.DataModels;
using universityApiBackend.Services.Interfaces;

namespace universityApiBackend.Services
{
    public class ChaptersServices: IChaptersServices
    {
        private readonly UniversityDBContext _context;

        public ChaptersServices(UniversityDBContext context)
        {
            _context = context;
        }

        //Obtener temario de un curso concreto
        public IEnumerable<Chapters> GetChaptersByCourses(Course course)
            => _context.Chapters!.Where(chapter => chapter.CourseId == course.Id);

    }
}

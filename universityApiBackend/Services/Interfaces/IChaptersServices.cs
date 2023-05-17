using universityApiBackend.Models.DataModels;

namespace universityApiBackend.Services.Interfaces
{
    public interface IChaptersServices
    {
        // -> IChaptersService
        public IEnumerable<Chapters> GetChaptersByCourses(Course course);
    }
}

using Microsoft.EntityFrameworkCore;
using universityApiBackend.Models.DataModels;

namespace universityApiBackend.DataAccess
{
    public class UniversityDBContext: DbContext
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options): base(options) 
        {
            
        }

        //TODO: Add DbSets (Tables of our Data Base)
        public DbSet<User>? Users { get; set; }
        public DbSet<Course>? Courses { get; set; }

    }
}

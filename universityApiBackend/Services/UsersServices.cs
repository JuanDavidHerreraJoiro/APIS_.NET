using Microsoft.EntityFrameworkCore;
using System.Linq;
using universityApiBackend.DataAccess;
using universityApiBackend.Models.DataModels;

namespace universityApiBackend.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly UniversityDBContext _context;

        public UsersServices(UniversityDBContext context)
        {
            _context = context;
        }

        // -> UserService
        public IEnumerable<User> GetUserByEmail(string email)
            => _context.Users!.Where(user => user.Email.Contains(email));
    }
}

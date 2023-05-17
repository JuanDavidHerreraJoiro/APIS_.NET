using universityApiBackend.Models.DataModels;

namespace universityApiBackend.Services
{
    public interface IUsersServices
    {
        // -> IUserService
        public IEnumerable<User> GetUserByEmail(string email);
    }
}

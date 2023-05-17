using Microsoft.EntityFrameworkCore;
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

        
    }
}

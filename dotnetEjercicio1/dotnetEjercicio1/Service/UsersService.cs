using dotnetEjercicio1.DataAccess;
using dotnetEjercicio1.Models.DataModels;

namespace dotnetEjercicio1.Service
{
    public class UsersService : IUsuersSerice
    {

        private readonly UniversityDBContext _context;
      
        public UsersService(UniversityDBContext context)
        {
            _context = context;
            
        }

      
        public IEnumerable<User> GetUserForMail(string mail)
        {
            var users = from user in _context.Users
                        where user.Email == mail
                        select user;
            return users;
        }

    }
}

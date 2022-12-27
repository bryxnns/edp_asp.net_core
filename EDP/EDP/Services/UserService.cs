using EDP.Models;

namespace EDP.Services
{
	public class UserService
	{
        private readonly MyDbContext _context;

        public UserService(MyDbContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.User.OrderBy(m => m.name).ToList();
        }

        public User? GetUserByEmail(string email)
        {
            User? user = _context.User.FirstOrDefault(m => m.email.Equals(email));
            return user;
        }

        public User? GetUserById(string id)
        {
            User? user = _context.User.FirstOrDefault(m => m.email.Equals(id));
            return user;
        }

        public void AddUser(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.User.Update(user);
            _context.SaveChanges();
        }

        public User? Login(User user)
        {
            var username = _context.User.FirstOrDefault(m => m.email.Equals(user.email));

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(user.password, username.password);

            user.user_id = username.user_id;

            if(isValidPassword)
            {
                
                return user;
            }
            return null;
        }
    }
}

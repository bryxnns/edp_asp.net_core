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
			return _context.Users.OrderBy(u => u.user_id).ToList();
		}

		public User? GetUserById(string id)
		{
			User? user = _context.Users.FirstOrDefault(x => x.user_id.Equals(id));
			return user;
		}

		public void AddUser(User user)
		{
			_context.Users.Add(user);
			_context.SaveChanges();
		}

		public void UpdateUsere(User user)
		{
			_context.Users.Update(user);
			_context.SaveChanges();
		}
	}
}

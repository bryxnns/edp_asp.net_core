using EDP.Models;

namespace EDP.Services
{
    public class UserDonationService
    {
        private readonly MyDbContext _context;
        public UserDonationService(MyDbContext context)
        {
            _context = context;
        }

        public List<User_Donation> GetAll()
        {
            return _context.UserDonations.OrderBy(m => m.user_donation_id).ToList();
        }
        public User_Donation? GetUserDonationById(string id)
        {
            User_Donation? userdonation = _context.UserDonations.FirstOrDefault(x => x.user_donation_id.Equals(id));
            return userdonation;
        }
        public void AddUserDonation(User_Donation userdonation)
        {
            _context.UserDonations.Add(userdonation);
            _context.SaveChanges();
        }

        public void UpdateUserDonation(User_Donation userdonation)
        {
            _context.UserDonations.Update(userdonation);
            _context.SaveChanges();
        }
    }
}

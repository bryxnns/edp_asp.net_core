using EDP.Models;
using Microsoft.EntityFrameworkCore;

namespace EDP.Services
{
    public class DonationServices
    {
        private readonly MyDbContext _context;
        
        public DonationServices(MyDbContext context)
        {
            _context = context;
        }

        public List<Donations> GetAvailRequests()
        {
            return _context.Donations.Where(x => x.volunteer_user_id.Equals("")).ToList();
        }

        public Donations? GetDonationById(string id)
        {
            Donations? userdonation = _context.Donations.FirstOrDefault(x => x.user_donation_id.Equals(id));
            return userdonation;
        }
        public List<Donations> GetDonationByUserId(string userid)
        {
            return _context.Donations.Where(x => x.user_id.Equals(userid)).ToList();
        }
        public List<Donations> GetDonationByVolunteerId(string volunteerid)
        {
            return _context.Donations.Where(x => x.volunteer_user_id.Equals(volunteerid)).ToList();
        }

        public User? GetUserDetails(string userid)
        {
            User? user = _context.User.FirstOrDefault(x => x.user_id.Equals(userid));
            return user;
        }

        public void AddDonation(Donations donation)
        {
            _context.Donations.Add(donation);
            _context.SaveChanges();
        }

        public void UpdateDonation(Donations donation)
        {
            _context.Donations.Update(donation);
            _context.SaveChanges();
        }

        public void DeleteDonation(Donations donation)
        {
            _context.Donations.Remove(donation);
            _context.SaveChanges();
        }
    }
}

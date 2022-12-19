using EDP.Models;

namespace EDP.Services
{
    public class DonationDetailsService
    {
        private readonly MyDbContext _context;
        public DonationDetailsService(MyDbContext context)
        {
            _context = context;
        }

        public List<Donation_Details> GetAll()
        {
            return _context.DonationDetails.OrderBy(m => m.user_donation_id).ToList();
        }
        public Donation_Details? GetDonationDetailsById(string id)
        {
            Donation_Details? donationdetails = _context.DonationDetails.FirstOrDefault(x => x.user_donation_id.Equals(id));
            return donationdetails;
        }
        public void AddDonationDetails(Donation_Details donationdetails)
        {
            _context.DonationDetails.Add(donationdetails);
            _context.SaveChanges();
        }

        public void UpdateDonationDetails(Donation_Details donationdetails)
        {
            _context.DonationDetails.Update(donationdetails);
            _context.SaveChanges();
        }
    }
}

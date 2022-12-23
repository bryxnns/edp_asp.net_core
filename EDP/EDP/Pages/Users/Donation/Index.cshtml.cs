using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages.Users.Donation
{
    public class IndexModel : PageModel
    {
        public string UserID;
        private readonly DonationServices _donationServices;

        public List<Donations> DonationList { get; set; } = new();
        public IndexModel(DonationServices donationServices)
        {
            _donationServices = donationServices;
        }
        public void OnGet(string userid)
        {
            UserID = userid;
            DonationList = _donationServices.GetDonationByUserId(userid);
        }
    }
}

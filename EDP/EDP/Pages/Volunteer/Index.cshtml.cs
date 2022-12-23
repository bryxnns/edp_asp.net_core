using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages.Volunteer
{
    public class IndexModel : PageModel
    {
        private readonly DonationServices _donationServices;
        public string VolunteerUserID;

        public List<Donations> DonationList { get; set; } = new();

        [BindProperty]
        public Donations? myDonation { get; set; } = new();

        public IndexModel(DonationServices donationServices)
        {
            _donationServices = donationServices;
            
        }
        public void OnGet(string userid)
        {
            DonationList = _donationServices.GetAvailRequests();
            VolunteerUserID = userid;
        }

        public IActionResult OnPost(string donationid, string userid)
        {
            Donations? donation = _donationServices.GetDonationById(donationid);
            if (donation != null)
            {
                myDonation = donation;
                myDonation.volunteer_user_id = userid;
                myDonation.request = "Accepted";
                _donationServices.UpdateDonation(donation);

                return Redirect("/Volunteer/Requests?userid=" + userid);
            }
            else
            {
                //TempData["FlashMessage.Type"] = "danger";
                //TempData["FlashMessage.Text"] = string.Format("Product ID {0} not found", id);
                return Redirect("/Volunteer");
            }
        }
    }
}

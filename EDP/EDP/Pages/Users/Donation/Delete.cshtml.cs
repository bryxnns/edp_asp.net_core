using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages.Users.Donation
{
    public class DeleteModel : PageModel
    {
        private readonly DonationServices _donationServices;

        [BindProperty]
        public Donations myDonation { get; set; } = new();

        public DeleteModel(DonationServices donationServices)
        {
            _donationServices = donationServices;
        }
        public IActionResult OnGet(string id)
        {
            Donations? donation = _donationServices.GetDonationById(id);
            if (donation != null)
            {
                myDonation = donation;
                _donationServices.DeleteDonation(donation);
                return Redirect("/Users/Donation/?userid=" + myDonation.user_id);
            }
            else
            {
                //TempData["FlashMessage.Type"] = "danger";
                //TempData["FlashMessage.Text"] = string.Format("Product ID {0} not found", id);
                return Redirect("/Users/Donation");
            }
        }
    }
}

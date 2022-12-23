using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages.Users.Donation
{
    public class DetailsModel : PageModel
    {
        private readonly DonationServices _donationServices;

        [BindProperty]
        public Donations myDonation { get; set; } = new();

        public DetailsModel(DonationServices donationServices)
        {
            _donationServices = donationServices;
        }
        public IActionResult OnGet(string id)
        {
            Donations? donations = _donationServices.GetDonationById(id);
            if (donations != null)
            {
                myDonation = donations;
                return Page();
            }
            else
            {
                //TempData["FlashMessage.Type"] = "danger";
                //TempData["FlashMessage.Text"] = string.Format("Product ID {0} not found", id);
                return Redirect("/Users/Donation");
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _donationServices.UpdateDonation(myDonation);
                //TempData["FlashMessage.Type"] = "success";
                //TempData["FlashMessage.Text"] = string.Format("Product {0} is added", myUserDonation.user_donation_id);
                return Redirect("/Users/Donation?userid=" + myDonation.user_id);
            }
            return Page();
        }
    }
}

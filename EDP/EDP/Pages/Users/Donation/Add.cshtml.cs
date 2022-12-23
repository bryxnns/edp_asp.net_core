using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages.Users.Donation
{
    public class AddModel : PageModel
    {
        public string UUID;
        public string UserID;
        public string request = "Pending";
        public string status = "Incomplete";
        public string value = "nil";
        private DonationServices _donationServices;

        [BindProperty]
        public Donations myDonation { get; set; } = new();

        public AddModel(DonationServices donationServices)
        {
            _donationServices = donationServices;
        }
        public void generateUuid()
        {
            string uuid = Guid.NewGuid().ToString();
            UUID = uuid;
        }

        public void OnGet(string userid)
        {
            generateUuid();
            UserID = userid;
            User? userDetails = _donationServices.GetUserDetails(userid);
            myDonation.address = userDetails.address;
            myDonation.unit_no = userDetails.unit_No;
            myDonation.postal_code = userDetails.postal_Code;

            myDonation.collection_done = false;
            myDonation.drop_off_done = false;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                //check if donation alr exists
                Donations? donations = _donationServices.GetDonationById(myDonation.user_donation_id);
                if (donations != null)
                {
                    //TempData["FlashMessage.Type"] = "danger";
                    //TempData["FlashMessage.Text"] = string.Format("Donation ID {0} alreay exists", myUserDonation.user_donation_id);
                    return Page();
                }

                _donationServices.AddDonation(myDonation);

                //TempData["FlashMessage.Type"] = "success";
                //TempData["FlashMessage.Text"] = string.Format("Product {0} is added", myUserDonation.user_donation_id);
                return Redirect("/Users/Donation?userid=" + myDonation.user_id);
            }
            return Page();
        }
    }
}

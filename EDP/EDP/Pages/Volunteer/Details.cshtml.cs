using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages.Volunteer
{
    public class DetailsModel : PageModel
    {
        private readonly DonationServices _donationServices;
        private IWebHostEnvironment _environment;
        //public Donations DonationList { get; set; } = new();

        [BindProperty]
        public Donations myDonation { get; set; } = new();

        [BindProperty]
        public IFormFile? Upload { get; set; }

        public DetailsModel(DonationServices donationServices, IWebHostEnvironment environment)
        {
            _donationServices = donationServices;
            _environment = environment;
        }

        public void OnGet(string id)
        {
            //DonationList = _donationServices.GetDonationById(id);
            
            Donations? donation = _donationServices.GetDonationById(id);
            if (donation != null)
            {
                myDonation = donation;
                if (myDonation.waste_weight == "nil")
                {
                    myDonation.waste_weight = "";
                }
                if (myDonation.drop_off_point == "nil")
                {
                    myDonation.drop_off_point = "";
                }
            }
            else
            {
                //TempData["FlashMessage.Type"] = "danger";
                //TempData["FlashMessage.Text"] = string.Format("Product ID {0} not found", id);
                //return Redirect("/Volunteer");
            }
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Upload != null)
                {
                    if (Upload.Length > 2 * 1024 * 1024)
                    {
                        ModelState.AddModelError("Upload", "File size cannot exceed 2MB.");
                        return Page();
                    }
                    var uploadsFolder = "images";
                    var imageFile = Guid.NewGuid() + Path.GetExtension(Upload.FileName);
                    var imagePath = Path.Combine(_environment.ContentRootPath, "wwwroot", uploadsFolder, imageFile);
                    using var fileStream = new FileStream(imagePath, FileMode.Create);
                    await Upload.CopyToAsync(fileStream);
                    myDonation.waste_image = string.Format("/{0}/{1}", uploadsFolder, imageFile);
                }

                _donationServices.UpdateDonation(myDonation);
                //TempData["FlashMessage.Type"] = "success";
                //TempData["FlashMessage.Text"] = string.Format("Product {0} is updated", myProduct.product_name);
                return Redirect("/Volunteer/Requests?userid=" + myDonation.volunteer_user_id);
            }
            return Page();
        }
    }
}

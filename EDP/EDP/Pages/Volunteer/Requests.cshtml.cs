using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace EDP.Pages.Volunteer
{
    public class RequestsModel : PageModel
    {
        private readonly DonationServices _donationServices;
        private IWebHostEnvironment _environment;

        public string UserID;
        public string DonationID;

        public List<Donations> DonationList { get; set; } = new();

        [BindProperty]
        public Donations? myDonation { get; set; } = new();

        [BindProperty]
        public IFormFile? Upload { get; set; }

        public RequestsModel(DonationServices donationServices, IWebHostEnvironment environment)
        {
            _donationServices = donationServices;
            _environment = environment;
        }
        public async Task<IActionResult> OnGet(string userid)
        {
            DonationList = _donationServices.GetDonationByVolunteerId(userid);

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

            return Page();
        }
    }
}

using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages.Users.Product.Review
{
    public class AddModel : PageModel
    {
        public string UUID;
        public string ProductID;
        public string UserID;

        private readonly ReviewService _reviewService;
        private IWebHostEnvironment _environment;

        [BindProperty]
        public Reviews myReviews { get; set; } = new();

        [BindProperty]
        public IFormFile? Upload { get; set; }

        public AddModel(ReviewService reviewService, IWebHostEnvironment environment)
        {
            _reviewService = reviewService;
            _environment = environment;
        }
        public void generateUuid()
        {
            string uuid = Guid.NewGuid().ToString();
            UUID = uuid;
        }

        public void OnGet(string productid, string userid)
        {
            generateUuid();
            ProductID = productid;
            UserID = userid;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                //image upload
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
                    myReviews.review_image = string.Format("/{0}/{1}", uploadsFolder, imageFile);
                }  
            }

            //check if alr exists
            Reviews? review = _reviewService.GetReviewById(myReviews.review_id);
            if (review != null)
            {
                //TempData["FlashMessage.Type"] = "danger";
                //TempData["FlashMessage.Text"] = string.Format("Product ID {0} alreay exists", myProduct.product_id);
                return Page();
            }

            //add review
            _reviewService.AddReview(myReviews);
            //TempData["FlashMessage.Type"] = "success";
            //TempData["FlashMessage.Text"] = string.Format("Product {0} is added", myProduct.product_name);

            return Redirect("/Users/Product");
        }
    }
}

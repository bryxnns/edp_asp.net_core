using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages.Users.Product.Review
{
    public class DeleteModel : PageModel
    {
        private readonly ReviewService _reviewService;

        [BindProperty]
        public Reviews myReviews { get; set; } = new();

        public DeleteModel(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public IActionResult OnGet(string id)
        {
            Reviews? review = _reviewService.GetReviewById(id);
            if (review != null)
            {
                myReviews = review;
                _reviewService.DeleteReview(myReviews);
                return Redirect("/Users/Product/Review?userid=" + myReviews.user_id);
            }
            else
            {
                //TempData["FlashMessage.Type"] = "danger";
                //TempData["FlashMessage.Text"] = string.Format("Product ID {0} not found", id);
                return Redirect("/Users/Product/Review");
            }
        }
    }
}

using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages.Users.Product.Review
{
    public class IndexModel : PageModel
    {
        private readonly ReviewService _reviewService;

        public List<Reviews> ReviewsByUserList { get; set; } = new();

        public IndexModel(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public void OnGet(string userid)
        {
            ReviewsByUserList = _reviewService.GetReviewByUserId(userid);
        }
    }
}

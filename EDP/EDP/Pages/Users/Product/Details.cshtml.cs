using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages.Users.Product
{
    public class DetailsModel : PageModel
    {
        private readonly ProductService _productService;
        private readonly ReviewService _reviewService;

        public List<Reviews> ReviewsList { get; set; } = new();

        [BindProperty]
        public Products myProduct { get; set; } = new();

        public DetailsModel(ProductService productService, ReviewService reviewService)
        {
            _productService = productService;
            _reviewService = reviewService;
        }

        public IActionResult OnGet(string id)
        {
            Products? product = _productService.GetProductsById(id);
            if (product != null)
            {
                myProduct = product;
                ReviewsList = _reviewService.GetReviewByProductId(id);
                return Page();
            }
            else
            {
                //TempData["FlashMessage.Type"] = "danger";
                //TempData["FlashMessage.Text"] = string.Format("Product ID {0} not found", id);
                return Redirect("/Product");
            }
        }
    }
}

using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages.Users.Product
{
    public class DetailsModel : PageModel
    {
        private readonly ProductService _productService;

        [BindProperty]
        public Products myProduct { get; set; } = new();

        public DetailsModel(ProductService productService)
        {
            _productService = productService;
        }

        public IActionResult OnGet(string id)
        {
            Products? product = _productService.GetProductsById(id);
            if (product != null)
            {
                myProduct = product;
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

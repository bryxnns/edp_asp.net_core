using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages.Users.Product
{
    public class IndexModel : PageModel
    {
        private readonly ProductService _productService;
        public List<Products> AllProductsList { get; set; } = new();

        public IndexModel(ProductService productService)
        {
            _productService = productService;
        }
        public void OnGet()
        {
            AllProductsList = _productService.GetAll();
        }
    }
}

using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages.User
{
    public class ProductsModel : PageModel
    {
        private readonly ProductService _productService;

        public List<Products> AllProductsList { get; set; } = new();

        public ProductsModel(ProductService productService)
        {
            _productService = productService;
        }
        public void OnGet()
        {
            AllProductsList = _productService.GetAll();
        }
    }
}

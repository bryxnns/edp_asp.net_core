using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages.Product
{
    public class IndexModel : PageModel
    {
        public string UserID;
        private readonly ProductService _productService;

        [BindProperty]
        public IFormFile? Upload { get; set; }

        public List<Products> ProductList { get; set; } = new();
        public IndexModel(ProductService productService)
        {
            _productService = productService;
        }
        public void OnGet(string userid)
        {
            UserID = userid;
            ProductList = _productService.GetProductsByUserId(userid);
        }
    }
}

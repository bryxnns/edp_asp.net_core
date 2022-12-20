using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages.Product
{
    public class DetailsModel : PageModel
    {
        private readonly ProductService _productService;
        private IWebHostEnvironment _environment;

        [BindProperty]
        public Products myProduct { get; set; } = new();

        [BindProperty]
        public IFormFile? Upload { get; set; }

        public static List<ProductCategory> CategoryList { get; set; } = new()
        {
            new ProductCategory{ category_name = "Fertilisers"},
            new ProductCategory{ category_name = "Food" }
        };

        public DetailsModel(ProductService productService, IWebHostEnvironment environment)
        {
            _productService = productService;
            _environment = environment;
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
                    myProduct.product_image = string.Format("/{0}/{1}", uploadsFolder, imageFile);
                }

                _productService.UpdateProduct(myProduct);
                //TempData["FlashMessage.Type"] = "success";
                //TempData["FlashMessage.Text"] = string.Format("Product {0} is updated", myProduct.product_name);
                return Redirect("/Product?userid=" + myProduct.User_ID);
            }
            return Page();
        }
    }
}

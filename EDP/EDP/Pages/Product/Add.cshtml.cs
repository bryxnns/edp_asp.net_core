using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using System;

namespace EDP.Pages.Product
{
    public class AddModel : PageModel
    {
        public string UUID;
        public string UserID;

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

        public AddModel(ProductService productService, IWebHostEnvironment environment)
        {
            _productService = productService;
            _environment = environment;
        }

        public void generateUuid()
        {
            string uuid = Guid.NewGuid().ToString();
            UUID = uuid;
        }

        public void OnGet(string userid)
        {
            generateUuid();
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
                    myProduct.product_image = string.Format("/{0}/{1}", uploadsFolder, imageFile);
                }

                //check if product alr exists
                Products? product = _productService.GetProductsById(myProduct.product_id);
                if (product != null)
                {
                    //TempData["FlashMessage.Type"] = "danger";
                    //TempData["FlashMessage.Text"] = string.Format("Product ID {0} alreay exists", myProduct.product_id);
                    return Page();
                }

                //add product
                _productService.AddProduct(myProduct);
                //TempData["FlashMessage.Type"] = "success";
                //TempData["FlashMessage.Text"] = string.Format("Product {0} is added", myProduct.product_name);
                
                //shld redirect to the particular merchant products page
                return Redirect("/Product?userid=" + myProduct.User_ID);
            }
            return Page();
        }
    }
}

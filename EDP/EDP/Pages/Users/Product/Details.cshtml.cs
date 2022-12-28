using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages.Users.Product
{
    public class DetailsModel : PageModel
    {
        private readonly ProductService _productService;
        private readonly CartService _cartService;

        public Products myProduct { get; set; } = new();

        public string UUID;
        public int Quantity=1;

        public DetailsModel(ProductService productService, CartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }
        public void generateUuid()
        {
            string uuid = Guid.NewGuid().ToString();
            UUID = uuid;
        }

        public IActionResult OnGet(string id)
        {
            generateUuid();
            var userCartItems = _cartService.GetAllCartItems(user_id);

            Products? product = _productService.GetProductsById(id);
            if (product != null)
            {
                myProduct = product;
                foreach (var item in userCartItems)
                {
                    if (item.product_id == MyCart.product_id)
                    { 
                        MyCart=item;
                        Quantity=item.quantity;
                        break;
                    }
                }
                        return Page();
            }
            else
            {
                //TempData["FlashMessage.Type"] = "danger";
                //TempData["FlashMessage.Text"] = string.Format("Product ID {0} not found", id);
                return Redirect("/Product");
            }

        }


        [BindProperty]
        public Cart MyCart { get; set; } = new();
        public string user_id = "ANSBEFKJF12";

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {


                //Add/Update CartItem 
                var notInCart = true;
                var userCartItems = _cartService.GetAllCartItems(user_id);
                foreach(var item in userCartItems)
                {
                    if (item.product_id == MyCart.product_id)
                    {
                        notInCart = false;
                        var chosenCartItem=_cartService.GetCartItemById(item.cart_id);
                        if (chosenCartItem != null)
                        {
                            chosenCartItem.quantity=MyCart.quantity;
                            _cartService.UpdateCartItem(chosenCartItem);
                        }

                    }
                }
                if (notInCart)
                {
                    _cartService.AddtoCart(MyCart);
                }
                
                //TempData["FlashMessage.Type"] = "success";
                //TempData["FlashMessage.Text"] = string.Format("Voucher {0} is added", MyVoucher.voucher_name);
                return Redirect("/mycart");
            }
            return Page();
        }


    }
}

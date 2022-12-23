using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages
{
    public class mycartModel : PageModel
    {
        private readonly ClaimVoucherService _claimVoucherService;
        private readonly ProductService _productService;
        private readonly CartService _cartService;
        private readonly VoucherService _voucherService;
        public Cart MyCart { get; set; } = new();
        public List<Products> UserProds { get; set; } = new();
        public List<Cart> UserCartItems { get; set; } = new();

        public mycartModel(VoucherService voucherService,ClaimVoucherService claimVoucherService, CartService cartService, ProductService productService)
        {
            _voucherService = voucherService;
            _claimVoucherService = claimVoucherService;
            _productService = productService;
            _cartService = cartService;
             
        }
        public void OnGet()
        {

            //Adding product to cart test
            var userid = "ANSBEFKJF12";
            //string uuid = Guid.NewGuid().ToString();
            //MyCart.cart_id = uuid;
            //MyCart.product_id = "de323e22-cc24-4e5e-89f1-ca7cd3f2d240";
            //MyCart.user_id = userid;
            //MyCart.quantity = 1;
            //_cartService.AddtoCart(MyCart);


            UserCartItems = _cartService.GetAllCartItems(userid);
            UserProds=_cartService.GetAllProductsInCart(userid);

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                foreach(var item in UserCartItems)
                {
                    _cartService.UpdateCartItem(item);
                }

            }
            return Redirect("/mycart");
        }


        }
}

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

        public List<Voucher> UserVouchers { get; set; } = new();

        public double totalPrice { get; set; }
        public double subTotal = 0.00;
        public double discountedPrice { get; set; }
        public double shippingFee = 1.00;
        public double shippingGuarantee = 1.37;
        public Voucher selectedVoucher { get; set; }
        public double Discount { get; set; }

        public mycartModel(VoucherService voucherService,ClaimVoucherService claimVoucherService, CartService cartService, ProductService productService)
        {
            _voucherService = voucherService;
            _claimVoucherService = claimVoucherService;
            _productService = productService;
            _cartService = cartService;
             
        }
        public void OnGet(string? voucherid)
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
            UserProds = _cartService.GetAllProductsInCart(userid);
            UserVouchers = _claimVoucherService.GetAllUserVouchers(userid);
            foreach (var item in UserCartItems)
            {
                foreach (var product in UserProds)
                {
                    if (item.product_id == product.product_id)
                    {
                        var price = product.price * item.quantity;
                        subTotal += decimal.ToDouble(price);
                    }
                }
            }
            totalPrice = subTotal + shippingFee + shippingGuarantee;

            if (voucherid != null)
            {
                selectedVoucher = _voucherService.GetVoucherById(voucherid);
                if(selectedVoucher != null)
                {
                    Discount = totalPrice * (Convert.ToDouble((selectedVoucher.percentage_off)) / 100);
                    discountedPrice = totalPrice - Discount;
                }
               
            }


        }

       


        }
}

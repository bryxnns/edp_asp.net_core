using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages
{
    public class PaymentModel : PageModel
    {
        private readonly ClaimVoucherService _claimVoucherService;
        private readonly ProductService _productService;
        private readonly CartService _cartService;
        private readonly VoucherService _voucherService;
        private readonly PurchasedItemService _purchasedItemService;
        private readonly PurchaseHistoryService _purchaseHistoryService;

        public PaymentModel(PurchasedItemService purchasedItemService,PurchaseHistoryService purchaseHistoryService,VoucherService voucherService, ClaimVoucherService claimVoucherService, CartService cartService, ProductService productService)
        {
            _voucherService = voucherService;
            _claimVoucherService = claimVoucherService;
            _productService = productService;
            _cartService = cartService;
            _purchaseHistoryService = purchaseHistoryService;
            _purchasedItemService = purchasedItemService;

        }
        public List<Products> UserProds { get; set; } = new();
        public List<Cart> UserCartItems { get; set; } = new();
        public Voucher ChosenVoucher { get; set; }
        public double Discount { get; set; }
        public double totalPrice { get; set; }
        public double subTotal = 0.00;
        public double discountedPrice { get; set; }
        public double shippingFee = 1.00;
        public double shippingGuarantee = 1.37;

        public string paymentReferenceCode { get; set; }

        public Purchase_History PurchaseHistory { get; set; } = new();

        public void OnGet(string? voucherid) 
        {
            //testing until session is made & payment is done
            var userid = "ANSBEFKJF12";
            paymentReferenceCode = "testing";

            UserCartItems = _cartService.GetAllCartItems(userid);
            UserProds = _cartService.GetAllProductsInCart(userid);

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
                ChosenVoucher = _voucherService.GetVoucherById(voucherid);
                if (ChosenVoucher != null)
                {
                    Discount = totalPrice * (Convert.ToDouble((ChosenVoucher.percentage_off)) / 100);
                    discountedPrice = totalPrice - Discount;
                }

            }
        }
       
    }
}

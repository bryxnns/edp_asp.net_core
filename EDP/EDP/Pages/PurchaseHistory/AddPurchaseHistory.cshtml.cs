using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages.PurchaseHistory
{
    public class AddPurchaseHistoryModel : PageModel
    {
        private readonly ClaimVoucherService _claimVoucherService;
        private readonly ProductService _productService;
        private readonly CartService _cartService;
        private readonly VoucherService _voucherService;
        private readonly PurchasedItemService _purchasedItemService;
        private readonly PurchaseHistoryService _purchaseHistoryService;

        public AddPurchaseHistoryModel(PurchasedItemService purchasedItemService, PurchaseHistoryService purchaseHistoryService, VoucherService voucherService, ClaimVoucherService claimVoucherService, CartService cartService, ProductService productService)
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

        public async Task<IActionResult> OnGet(string? voucherid,string paymentReferenceCode)
        {
            //testing until session is made & payment is done
            var userid = "ANSBEFKJF12";

            string purchaseHistoryID = Guid.NewGuid().ToString();
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

            //adding purchase history
            PurchaseHistory.purchase_history_id = purchaseHistoryID;
            PurchaseHistory.purchase_date = DateTime.Now;
            PurchaseHistory.total_price = (decimal)(totalPrice);
            if (discountedPrice != null)
            {
                PurchaseHistory.discounted_price = (decimal)discountedPrice;
            }
            else
            {
                PurchaseHistory.discounted_price = 0;
            }
            PurchaseHistory.payment_reference_code = paymentReferenceCode;
            PurchaseHistory.user_id = userid;
            if(ChosenVoucher != null)
            {
                PurchaseHistory.voucher_name=ChosenVoucher.voucher_name;
                PurchaseHistory.percentage_off = int.Parse(ChosenVoucher.percentage_off) ;
            }
            _purchaseHistoryService.AddPurchaseHistory(PurchaseHistory);

            //adding purchased items 
            foreach (var item in UserCartItems)
            {
                foreach (var product in UserProds)
                {
                    if (item.product_id == product.product_id)
                    {
                        string purchasedItemUUID = Guid.NewGuid().ToString();
                        Purchased_Item purchasedItem=new Purchased_Item();
                        purchasedItem.price = product.price;
                        purchasedItem.quantity=item.quantity;
                        purchasedItem.purchase_history_id = purchaseHistoryID;
                        purchasedItem.product_name = product.product_name;
                        purchasedItem.purchased_item_id= purchasedItemUUID;
                        _purchasedItemService.AddPurchaseItem(purchasedItem);
                    }
                }
            }

            return Redirect("/PurchaseHistory/UserPurchaseHistories");

        }

        
    }
}

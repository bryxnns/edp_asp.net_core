using EDP.Models;

namespace EDP.Services
{
    public class PurchasedItemService
    {
        private readonly ClaimVoucherService _claimVoucherService;
        private readonly ProductService _productService;
        private readonly CartService _cartService;
        private readonly VoucherService _voucherService;
        private readonly MyDbContext _context;
        public PurchasedItemService(MyDbContext context,VoucherService voucherService, ClaimVoucherService claimVoucherService, CartService cartService, ProductService productService)
        {
            _voucherService = voucherService;
            _claimVoucherService = claimVoucherService;
            _productService = productService;
            _cartService = cartService;
            _context = context;

        }

        public List<Purchased_Item> GetAll()
        {
            return _context.PurchasedItems.OrderBy(d => d.purchase_history_id).ToList();
        }

        public List<Purchased_Item> GetALlItemsFromPHId(string purchasehistoryid)
        {
            return _context.PurchasedItems.Where(d => d.purchase_history_id == purchasehistoryid).ToList();
        }

        public void AddPurchaseItem(Purchased_Item purchaseItem)
        {
            _context.PurchasedItems.Add(purchaseItem);
            _context.SaveChanges();
        }
        public void DeletePurchaseItem(Purchased_Item purchaseItem)
        {

            _context.PurchasedItems.Remove(purchaseItem);
            _context.SaveChanges();

        }
    }
}

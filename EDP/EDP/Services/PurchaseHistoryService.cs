using EDP.Models;

namespace EDP.Services
{
    public class PurchaseHistoryService
    {
        private readonly ClaimVoucherService _claimVoucherService;
        private readonly ProductService _productService;
        private readonly CartService _cartService;
        private readonly VoucherService _voucherService;
        private readonly MyDbContext _context;
        public PurchaseHistoryService(MyDbContext context,VoucherService voucherService, ClaimVoucherService claimVoucherService, CartService cartService, ProductService productService)
        {
            _voucherService = voucherService;
            _claimVoucherService = claimVoucherService;
            _productService = productService;
            _cartService = cartService;
            _context = context;
        }

        public List<Purchase_History> GetAll()
        {
            return _context.PurchaseHistories.OrderBy(d => d.user_id).ToList();
        }

        public List<Purchase_History> GetALlItemsFromUser(string userid)
        {
            return _context.PurchaseHistories.Where(d => d.user_id == userid).ToList();
        }

        public void AddPurchaseHistory(Purchase_History purchaseHistory)
        {
            _context.PurchaseHistories.Add(purchaseHistory);
            _context.SaveChanges();
        }
        public void DeletePurchaseHistory(Purchase_History purchaseHistory)
        {

            _context.PurchaseHistories.Remove(purchaseHistory);
            _context.SaveChanges();

        }
    }
}

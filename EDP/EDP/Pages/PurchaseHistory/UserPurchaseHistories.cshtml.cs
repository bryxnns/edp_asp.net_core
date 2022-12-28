using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages.PurchaseHistory
{
    public class UserPurchaseHistoriesModel : PageModel
    {
        private readonly PurchasedItemService _purchasedItemService;
        private readonly PurchaseHistoryService _purchaseHistoryService;

        public UserPurchaseHistoriesModel(PurchasedItemService purchasedItemService, PurchaseHistoryService purchaseHistoryService)
        {
            _purchasedItemService = purchasedItemService;
            _purchaseHistoryService = purchaseHistoryService;

        }

        //testing until session is made & payment is done
        public string userid = "ANSBEFKJF12";

        public List<Purchase_History> UserPurchaseHistories { get; set; } = new();

        public List<Purchased_Item> UserPurchaseItems { get; set; } = new();

        public void OnGet()
        {
            UserPurchaseHistories = _purchaseHistoryService.GetAllUserPH(userid);
            foreach (var purchase in UserPurchaseHistories)
            {
                var items = _purchasedItemService.GetALlItemsFromPHId(purchase.purchase_history_id);
                foreach (var item in items)
                {
                    UserPurchaseItems.Add(item);
                }
            }
        }
    }
}

using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages.CartActions
{
    public class UpdateQuantityModel : PageModel
    {
        private readonly CartService _cartService;
        public UpdateQuantityModel(CartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<IActionResult> OnGet(string itemId, int quantity)
        {
            var cartItem = _cartService.GetCartItemById(itemId);
            if (cartItem != null)
            {
                cartItem.quantity = quantity;
                _cartService.UpdateCartItem(cartItem);
            }
            return Redirect("/mycart");
            
        }
    }
}

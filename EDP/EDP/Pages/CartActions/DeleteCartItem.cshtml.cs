using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages.CartActions
{
    public class DeleteCartItemModel : PageModel
    {
        private readonly CartService _cartService;
        public DeleteCartItemModel(CartService cartService)
        {
            _cartService = cartService;
        }
        public async Task<IActionResult> OnGet(string cartid)
        {
            var cartItem=_cartService.GetCartItemById(cartid);
            if (cartItem != null)
            {
                _cartService.DeleteCartItem(cartItem);

            }
            return Redirect("/mycart");
        }
    }
}

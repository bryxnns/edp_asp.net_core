using EDP.Models;

namespace EDP.Services
{
    public class CartService
    {
        private readonly UserService _userService;
        private readonly ProductService _productService;
        private readonly MyDbContext _context;
        public CartService(MyDbContext context,UserService userService,ProductService productService)
        {
            _context = context;
            _userService = userService;
            _productService = productService;
        }

        public List<Cart> GetAll()
        {
            return _context.Carts.OrderBy(d => d.user_id).ToList();
        }

        public List<Products> GetAllProductsInCart(string userid)
        {
            List<Products> userProds=new List<Products>();
            List<Cart> UserCart=GetAllCartItems(userid);
            var allProds = _productService.GetAll();
            foreach(var item in UserCart)
            {
                foreach(var product in allProds)
                {
                    if (item.product_id == product.product_id)
                    {
                        userProds.Add(product);
                        break;
                    }
                }
                
            }
            return userProds;
        }

        public List<Cart> GetAllCartItems(string userid)
        {
            List<Cart> UserCart=new List<Cart>();
            var allCartItems=_context.Carts.OrderBy(d => d.user_id).ToList();
            foreach(var item in allCartItems)
            {
                if(item.user_id == userid)
                {
                    UserCart.Add(item);
                }
            }
            return UserCart;
        }

        public Cart? GetCartItemById(string id)
        {
            Cart? cartItem = _context.Carts.FirstOrDefault(
            x => x.cart_id.Equals(id));
            return cartItem;
        }

        public void AddtoCart(Cart cartItem)
        {
            _context.Carts.Add(cartItem);
            _context.SaveChanges();
        }

        public void UpdateCartItem(Cart cartItem)
        {
            _context.Carts.Update(cartItem);
            _context.SaveChanges();
        }

        public void DeleteCartItem(Cart cartItem)
        {

            _context.Carts.Remove(cartItem);
            _context.SaveChanges();

        }
    }
}

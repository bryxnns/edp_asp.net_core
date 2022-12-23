namespace EDP.Services
{
    public class CartService
    {
        private readonly MyDbContext _context;
        public CartService(MyDbContext context)
        {
            _context = context;
        }
    }
}

using EDP.Models;

namespace EDP.Services
{
    public class ProductService
    {
        private readonly MyDbContext _context;
        public ProductService(MyDbContext context)
        {
            _context = context;
        }

        public List<Products> GetAll()
        {
            return _context.Products.OrderBy(m => m.product_id).ToList();

        }
        public Products? GetProductsById(string id)
        {
            Products? product = _context.Products.FirstOrDefault(x => x.product_id.Equals(id));
            return product;
        }
        public void AddProduct(Products product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Products product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}

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
            return _context.Products.OrderBy(d => d.product_id).ToList();
        }

        public List<Products> GetProductsByUserId(string userid)
        {
            return _context.Products.Where(x => x.User_ID.Equals(userid)).ToList();
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

        public Boolean DeleteProduct(string id)
        {
            Products? product = _context.Products.FirstOrDefault(x => x.product_id.Equals(id));
            if (product != null)
            {
                _context.Products.Remove(product);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

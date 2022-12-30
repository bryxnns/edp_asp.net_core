using Microsoft.EntityFrameworkCore;
using EDP.Models;

namespace EDP
{
    public class MyDbContext : DbContext
    {
		private readonly IConfiguration _configuration;
		public MyDbContext(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			string connectionString = _configuration.GetConnectionString("MyConnection");
			optionsBuilder.UseSqlServer(connectionString);
		}


		public DbSet<User> User { get; set; }
		public DbSet<Cart> Carts { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
		public DbSet<Products> Products { get; set; }        
		public DbSet<Donations> Donations { get; set; }
		public DbSet<Purchased_Item> PurchasedItems { get; set; }
		public DbSet<Claimed_Voucher> ClaimedVouchers { get; set; }
		public DbSet<Purchase_History> PurchaseHistories { get; set; }
        

        

        
    }
}

using EDP.Models;

namespace EDP.Services
{
    public class VoucherService
    {
        private readonly MyDbContext _context;
        public VoucherService(MyDbContext context)
        {
            _context = context;
        }
        public List<Voucher> GetAll()
        {
            return _context.Vouchers.OrderBy(d => d.voucher_name).ToList();
        }
        public Voucher? GetDepartmentById(string id)
        {
            Voucher? voucher = _context.Vouchers.FirstOrDefault(
            x => x.voucher_id.Equals(id));
            return voucher;
        }
    }
}

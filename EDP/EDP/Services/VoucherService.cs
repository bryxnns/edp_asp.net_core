using EDP.Models;
using System;

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
        public List<Voucher> GetAllClaimable(int points)
        {
            var allVouchers= _context.Vouchers.OrderBy(d => d.voucher_name).ToList();
            List<Voucher> Claimable = new List<Voucher>();
            foreach(var voucher in allVouchers)
            {
                if (voucher.points_required <= points)
                {
                    Claimable.Add(voucher);
                }
            }
            return Claimable;
        }

        public Voucher? GetVoucherById(string id)
        {
            Voucher? voucher = _context.Vouchers.FirstOrDefault(
            x => x.voucher_id.Equals(id));
            return voucher;
        }
        public void AddVoucher(Voucher voucher)
        {
            _context.Vouchers.Add(voucher);
            _context.SaveChanges();
        }

        public void UpdateVoucher(Voucher voucher)
        {
            _context.Vouchers.Update(voucher);
            _context.SaveChanges();
        }

        public void DeleteVoucher(Voucher voucher)
        {

            _context.Vouchers.Remove(voucher);
            _context.SaveChanges();

        }
    }
}

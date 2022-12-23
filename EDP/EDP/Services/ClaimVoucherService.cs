using EDP.Models;

namespace EDP.Services
{
    public class ClaimVoucherService
    {
        private readonly VoucherService _voucherService;
        private readonly MyDbContext _context;
        public ClaimVoucherService(MyDbContext context,VoucherService voucherService)
        {
            _context = context;
            _voucherService = voucherService;
        }
        public List<Claimed_Voucher> GetAll()
        {
            return _context.ClaimedVouchers.OrderBy(d => d.claimed_voucher_id).ToList();
        }

        public List<Voucher> GetAllUserVouchers(string userid)
        {
            List<Claimed_Voucher> userVouchers=new List<Claimed_Voucher>();
            List<Voucher> allVouchers = new List<Voucher>();
            List<Voucher> userClaimedVouchers = new List<Voucher>();
            allVouchers = _voucherService.GetAll();
            var allClaimedVouchers= _context.ClaimedVouchers.OrderBy(d => d.claimed_voucher_id).ToList();
            foreach(var claimed in allClaimedVouchers)
            {
                if (claimed.user_id == userid)
                {
                    userVouchers.Add(claimed);
                }
            }
            foreach(var c in userVouchers)
            {
                foreach(var i in allVouchers)
                {
                    if (c.voucher_id == i.voucher_id)
                    {
                        if(i.expiry_date <= DateTime.Now)
                        {
                            userClaimedVouchers.Add(i);
                            break;
                        }
                        else
                        {
                            _context.Remove(c);
                        }
                    }
                }
            }
            return userClaimedVouchers;
        }

        public Claimed_Voucher? GetClaimedVoucherById(string id)
        {
            Claimed_Voucher? claimed_voucher = _context.ClaimedVouchers.FirstOrDefault(
            x => x.claimed_voucher_id.Equals(id));
            return claimed_voucher;
        }
        public void AddClaimedVoucher(Claimed_Voucher claimedvoucher)
        {
            _context.ClaimedVouchers.Add(claimedvoucher);
            _context.SaveChanges();
        }

        public void DeleteVoucher(Claimed_Voucher claimedvoucher)
        {

            _context.ClaimedVouchers.Remove(claimedvoucher);
            _context.SaveChanges();

        }
    }
}

using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages.Vouchers
{
    public class IndexModel : PageModel
    {
        private readonly VoucherService _voucherService;
        public IndexModel(VoucherService voucherService)
        {
            _voucherService = voucherService;
        }
        public List<Voucher> VoucherList { get; set; }
        public void OnGet()
        {
            VoucherList = _voucherService.GetAll();
        }
    }
}

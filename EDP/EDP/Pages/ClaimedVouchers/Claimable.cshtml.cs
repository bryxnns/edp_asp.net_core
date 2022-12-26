using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages.ClaimedVouchers
{
    public class ClaimableModel : PageModel
    {
        private readonly VoucherService _voucherService;
        private readonly UserService _userService;
        private readonly ClaimVoucherService _claimVoucherService;
        public ClaimableModel(VoucherService voucherService, UserService userService, ClaimVoucherService claimVoucherService)
        {
            _voucherService = voucherService;
            _userService = userService;
            _claimVoucherService = claimVoucherService;
        }
        public List<Voucher> VoucherList { get; set; }
        public void OnGet(double minSpend)
        {
            var userid = "ANSBEFKJF12";
            VoucherList = _claimVoucherService.GetAllUserVouchersCart(userid,minSpend);

        }
    }
}

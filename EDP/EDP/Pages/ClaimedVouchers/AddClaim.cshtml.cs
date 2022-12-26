using EDP.Services;
using EDP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages.ClaimedVouchers
{
    public class AddClaimModel : PageModel
    {
        private readonly ClaimVoucherService _claimVoucherService;
        public string UUID;
        public Claimed_Voucher MyClaimedVoucher { get; set; } = new();
        public AddClaimModel(ClaimVoucherService claimvoucherService)
        {
            _claimVoucherService = claimvoucherService;
        }
        public async Task<IActionResult> OnGet(string voucherid)
        {
            var userid = "ANSBEFKJF12";
            generateUuid();
            MyClaimedVoucher.user_id = userid;
            MyClaimedVoucher.voucher_id=voucherid;
            MyClaimedVoucher.claimed_voucher_id = UUID;
            _claimVoucherService.AddClaimedVoucher(MyClaimedVoucher);
            return Redirect("/ClaimedVouchers/ClaimedVoucher");

        }
        public void generateUuid()
        {
            string uuid = Guid.NewGuid().ToString();
            UUID = uuid;
        }

    }
}

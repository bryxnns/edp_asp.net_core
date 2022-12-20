using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages.Vouchers
{
    public class DeleteModel : PageModel
    {
        private readonly VoucherService _voucherService;
        public DeleteModel(VoucherService voucherService)
        {
            _voucherService = voucherService;
        }
        [BindProperty]
        public Voucher MyVoucher { get; set; } = new();
        public IActionResult OnGet(string id)
        {


            Voucher? voucher = _voucherService.GetVoucherById(id);
            if (voucher != null)
            {
                MyVoucher = voucher;
                _voucherService.DeleteVoucher(voucher);
                return Redirect("/Vouchers");
            }
            else
            {
                //TempData["FlashMessage.Type"] = "danger";
                //TempData["FlashMessage.Text"] = string.Format("Employee ID {0} not found", id);
                return Redirect("/Vouchers");
            }
        }
    }
}

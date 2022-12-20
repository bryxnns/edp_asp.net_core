using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages.Vouchers
{
    public class UpdateModel : PageModel
    {
        private readonly VoucherService _voucherService;
        public UpdateModel(VoucherService voucherService)
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
                return Page();
            }
            else
            {
                //TempData["FlashMessage.Type"] = "danger";
                //TempData["FlashMessage.Text"] = string.Format("Employee ID {0} not found", id);
                return Redirect("/Vouchers");
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {

                _voucherService.UpdateVoucher(MyVoucher);
                //TempData["FlashMessage.Type"] = "success";
                //TempData["FlashMessage.Text"] = string.Format(
                //"Employee {0} is updated", MyEmployee.Name);
                return Redirect("/Vouchers");
            }
            return Page();
        }
    }
}

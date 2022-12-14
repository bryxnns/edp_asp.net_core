using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages.Vouchers
{
    public class AddModel : PageModel
    {
        private readonly VoucherService _voucherService;
        public AddModel(VoucherService voucherService)
        {
            _voucherService = voucherService;
        }

        [BindProperty]
        public Voucher MyVoucher { get; set; } = new();

        public string UUID;
        public DateTime now = DateTime.Now;


        public void OnGet()
        {
            generateUuid();
            MyVoucher.expiry_date = now.AddDays(1);
        }
        public void generateUuid()
        {
            string uuid= Guid.NewGuid().ToString();
            UUID=uuid;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {

                //Check if voucher already exists
                Voucher? voucher = _voucherService.GetVoucherById(
                MyVoucher.voucher_id);
                if (voucher != null)
                {
                   
                    //TempData["FlashMessage.Type"] = "danger";
                    //TempData["FlashMessage.Text"] = string.Format("Voucher ID {0} alreay exists", MyVoucher.voucher_id);
                    return Page();
                    //ModelState.AddModelError("", error.Description);
                }
                //checking date
                if (MyVoucher.expiry_date < now.AddDays(1))
                {
                    ModelState.AddModelError("early date", "Date has to be day after today");
                }
                //Add Voucher 
                _voucherService.AddVoucher(MyVoucher);
                //TempData["FlashMessage.Type"] = "success";
                //TempData["FlashMessage.Text"] = string.Format("Voucher {0} is added", MyVoucher.voucher_name);
                return Redirect("/Vouchers");
            }
            return Page();
        }

    }
}

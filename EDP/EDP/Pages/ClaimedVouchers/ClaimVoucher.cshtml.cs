using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages
{
    public class ClaimVoucherModel : PageModel
    {
        private readonly VoucherService _voucherService;
        private readonly UserService _userService;
        public ClaimVoucherModel(VoucherService voucherService,UserService userService)
        {
            _voucherService = voucherService;
            _userService = userService;
        }
        public List<Voucher> VoucherList { get; set; }


        public void OnGet()
        {
            var user_id = "ANSBEFKJF12";


            VoucherList = _voucherService.GetAll();
            if(user_id!=null)
            {
                //var CurrentUser = _userService.GetUserById(user_id);
                var testPoints = 50;
                VoucherList=_voucherService.GetAllClaimable(testPoints);
            }
            
            
        }
    }
}

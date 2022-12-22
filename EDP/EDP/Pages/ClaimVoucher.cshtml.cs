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
        public List<Voucher> ValidVoucherList { get; set; }
      
        public void OnGet()
        {
            var user_id = 12;
            
            VoucherList = _voucherService.GetAll();
            if (user_id == null)
            {
                ValidVoucherList = _voucherService.GetAll();
            }
            else
            {
                var CurrentUser = _userService.GetUserById(user_id.ToString());
                foreach (var v in VoucherList)
                {
                    if(v.expiry_date > DateTime.Now && v.points_required >= Convert.ToInt16(CurrentUser.points))
                    {
                        ValidVoucherList.Add(v);
                    }
                }
            }
            
            
        }
    }
}

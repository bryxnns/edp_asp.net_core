using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
            //Test
            var userid = "ANSBEFKJF12";
            HttpContext.Session.SetString("userid", userid);
        }
    }
}

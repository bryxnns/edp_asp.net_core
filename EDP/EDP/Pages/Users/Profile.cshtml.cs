using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages.Users
{
    public class ProfileModel : PageModel
    {
        private readonly UserService _userService;


        public ProfileModel(UserService userService)
        {
            _userService = userService;
        }

        public string userid;

        public void OnGet()
        {
            userid = HttpContext.Session.GetString("user_id");
        }
    }
}

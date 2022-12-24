using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserService _userService;


		public RegisterModel(UserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public User MyUser { get; set; } = new();

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                User? user = _userService.GetUserByEmail(MyUser.email);

                if (user != null)
                {
                    TempData["FlashMessage.Type"] = "danger";
                    TempData["FlashMessage.Text"] = string.Format("Email already in used!");
                    return Page();
                }

                MyUser.password = BCrypt.Net.BCrypt.HashPassword(MyUser.password);
                MyUser.user_id= Guid.NewGuid().ToString();
                _userService.AddUser(MyUser);
                TempData["FlashMessage.Type"] = "success";
                TempData["FlashMessage.Text"] = string.Format("Successfully Registered Account!");

                return Redirect("/Login");
            }
            return Page();
        }

    }
}

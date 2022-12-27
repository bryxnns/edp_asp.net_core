using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EDP.Pages
{
    public class LoginModel : PageModel
    {
		private readonly UserService _userService;


		public LoginModel(UserService userService)
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
			if(ModelState.IsValid)
			{
				User? user = _userService.GetUserByEmail(MyUser.email);

				if(user != null)
				{
					User? valid = _userService.Login(MyUser);

					if(valid != null)
					{
						HttpContext.Session.SetString("user_id", valid.user_id);
						return Redirect("/Users/Profile");
					}
					else
					{
						TempData["FlashMessage.Type"] = "danger";
						TempData["FlashMessage.Text"] = string.Format("Incorrect Email or Password");
						return Page();
					}
				}
				else
				{
					TempData["FlashMessage.Type"] = "danger";
					TempData["FlashMessage.Text"] = string.Format("Incorrect Email or Password");
					return Page();
				}
			}
			return Page();

		}
	}
}

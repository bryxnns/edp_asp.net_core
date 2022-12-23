using EDP.Models;
using EDP.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace EDP.Pages
{
    public class RegisterModel : PageModel
    {

        private readonly UserService _userService;
        public string user_id = Guid.NewGuid().ToString();

        [BindProperty]
        public Models.User MyUser { get; set; } = new();

        public void OnGet()
        {
        }

		public IActionResult OnPost()
        {
            MyUser.user_id = user_id;
            Models.User? user = _userService.GetUserById(MyUser.user_id);
            _userService.AddUser(MyUser);
            Debug.WriteLine("user registered successfully");

			return Page();
        }

	}
}

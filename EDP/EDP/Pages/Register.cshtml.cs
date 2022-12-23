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

        public string userID = Guid.NewGuid().ToString();

        public RegisterModel(  user_service)
        {
			_userService = user_service;
        }

        [BindProperty]
        public Models.User MyUser { get; set; } = new();

        public void OnGet()
        {
        }

		public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
				MyUser.user_id = userID;
				_userService.AddUser(MyUser);
				Debug.WriteLine("user registered successfully");
			}

			return Page();
        }

	}
}

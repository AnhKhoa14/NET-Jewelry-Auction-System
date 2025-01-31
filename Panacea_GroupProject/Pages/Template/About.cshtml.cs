using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;
using System.Security.Claims;

namespace Panacea_GroupProject.Pages.Template
{
    public class AboutModel : PageModel
    {
		private readonly IUserService _userService;

		public User LoggedInUser { get; private set; }
		public AboutModel(IUserService userService)
		{
			_userService = userService;
		}
		public IActionResult OnGet()
        {
			var claimsIdentity = User.Identity as ClaimsIdentity;
			var userIdClaim = claimsIdentity?.FindFirst("Id");
			if (userIdClaim == null)
			{
				return RedirectToPage("/Accounts/Login");
			}

			LoggedInUser = _userService.GetUserByID(int.Parse(userIdClaim.Value));

			if (LoggedInUser == null)
			{
				return RedirectToPage("/Accounts/Login");
			}

			return Page();
		}
    }
}

using CoreLayout.Models.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations;

namespace AuthenticationTask.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;
        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }
        // Properties
        [Required(ErrorMessage = "Username is required")]
        [MaxLength(50, ErrorMessage = "Username cannot exceed 50 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }
        // End Properties

        public void OnGet()
        {
        }
        public IActionResult OnPost(string Username , string Password)
        {
            var result = _userService.Login(new CoreLayout.DTOS.User.Login()
            {
                Username = Username,
                Password = Password
            });
            var test = "test";
            if(result != null)
            {
				List<Claim> claimList = new List<Claim>
					{
						new Claim(ClaimTypes.NameIdentifier,result.Id.ToString()),
						new Claim(ClaimTypes.Name , result.fullName),
					};
				var identity = new ClaimsIdentity(claimList, CookieAuthenticationDefaults.AuthenticationScheme);
				var clientPrinciple = new ClaimsPrincipal(identity);
				var properties = new AuthenticationProperties()
				{
					IsPersistent = true,
				};
				HttpContext.SignInAsync(clientPrinciple, properties);
                TempData["status"] = "You loggined successfully";
                return RedirectToPage("/Index");
			}
            else
            {
                TempData["status"] = "Your information are wrong!";
                return RedirectToPage();
			}
			
        }
    }
}

using CoreLayout.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace AuthenticationTask.Pages.Auth
{
    public class SignUp : PageModel
    {
        // Properties
        [Required(ErrorMessage = "Username is required")]
        [MaxLength(50, ErrorMessage = "Username cannot exceed 50 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [MaxLength(100, ErrorMessage = "Full name cannot exceed 100 characters")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
        // End Properties

        public readonly IUserService _userService;
        public SignUp(IUserService userService)
        {
            _userService = userService;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(string Username , string Fullname , string Email , string Password, string ConfirmPassword)

        {
            var result = _userService.Register(new CoreLayout.DTOS.User.SignIn
            {
                Fullname = Fullname , 
                Email = Email ,
                Password = Password ,
                Username = Username ,
                confirmPassword = ConfirmPassword
			});
            if (result.status == 200)
            {
                TempData["status"] = result.Message;
                return RedirectToPage("login");

                
            }
            else
            {
                TempData["status"] = result.Message;
                return RedirectToPage();
			}
            
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Friberg_Car_Rentals__Razor_Pages_3_.Pages.Account
{
    public class LoginModel : PageModel
    {
        [TempData]
        public string ErrorMessage { get; set; }

        public IActionResult OnPost(string username, string password)
        {
            // Your login logic here
            if (username == "admin" && password == "adminpassword")
            {
                HttpContext.Session.SetString("UserRole", "Admin");
                return RedirectToPage("/Admin/Index");
            }
            else if (username == "user" && password == "userpassword")
            {
                HttpContext.Session.SetString("UserRole", "User");
                return RedirectToPage("/Customers/Create");
            }
            else
            {
                // Login failed, display error message
                ErrorMessage = "Invalid username or password.";
                return Page();
            }
        }
    }
}

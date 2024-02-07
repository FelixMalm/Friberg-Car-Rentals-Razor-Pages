using Friberg_Car_Rentals__Razor_Pages_3_.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Friberg_Car_Rentals__Razor_Pages_3_.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly ICustomer customerRep;

        public LoginModel(ICustomer customerRep)
        {
            this.customerRep = customerRep;
        }

        [TempData]
        public string ErrorMessage { get; set; }

        public IActionResult OnPost(string username, string password)
        {
            var customer = customerRep.GetCustomerByUsername(username);

            if (customer != null && customer.Password == password)
            {
                HttpContext.Session.SetString("CustomerId", customer.Id.ToString());

                HttpContext.Session.SetString("UserRole", customer.Role);

                //TempData["UserRole"] = customer.Role;

                //ViewData["UserRole"] = customer.Role;

                return RedirectToPage("/Index");
                //return Page();
            }
            else
            {
                ErrorMessage = "Invalid username or password.";
                return Page();
            }
        }
    }
}

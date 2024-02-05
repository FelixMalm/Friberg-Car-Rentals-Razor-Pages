using Friberg_Car_Rentals__Razor_Pages_3_.Repository;
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

        //public IActionResult OnPost(string username, string password)
        //{
        //    var customer = customerRep.GetCustomerByUsername(username);

        //    if (customer != null && customer.Password == password)
        //    {
        //        HttpContext.Session.SetString("CustomerId", customer.Id.ToString());

        //        // Redirect to customer-specific page
        //        return RedirectToPage("/Customers/Index");
        //    }

        //    ErrorMessage = "Invalid username or password.";
        //    return Page();
        //}
    }
}

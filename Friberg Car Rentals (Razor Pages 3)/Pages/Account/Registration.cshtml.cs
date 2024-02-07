using Friberg_Car_Rentals__Razor_Pages_.Data;
using Friberg_Car_Rentals__Razor_Pages_3_.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Friberg_Car_Rentals__Razor_Pages_3_.Pages.Account
{
    public class RegistrationModel : PageModel
    {
        private readonly ICustomer customerRep;

        public RegistrationModel(ICustomer customerRep)
        {
            this.customerRep = customerRep;
        }

        public void OnPost(string firstName, string lastName, string newUsername, string newPassword)
        {
            if (string.IsNullOrEmpty(newPassword))
            {
                ModelState.AddModelError(nameof(newPassword), "Password is required");
            }
            else if (newPassword.Length < 6)
            {
                ModelState.AddModelError(nameof(newPassword), "Password must be at least 6 characters long");
            }

            if (!ModelState.IsValid)
            {
                // Return the current page with validation errors
                return;
            }

            var customer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Username = newUsername,
                Password = newPassword,
                Role = "User"
            };

            customerRep.Add(customer);

            RedirectToPage("/Account/RegistrationConfirmation");
        }
    }
}

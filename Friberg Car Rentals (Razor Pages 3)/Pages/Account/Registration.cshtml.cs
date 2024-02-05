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
    }
}

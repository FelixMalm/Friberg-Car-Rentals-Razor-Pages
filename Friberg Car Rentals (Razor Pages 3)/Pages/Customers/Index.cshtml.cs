using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Friberg_Car_Rentals__Razor_Pages_.Data;
using Friberg_Car_Rentals__Razor_Pages_3_.Data;
using Friberg_Car_Rentals__Razor_Pages_3_.Repository;

namespace Friberg_Car_Rentals__Razor_Pages_3_.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly ICustomer customerRep;

        public IndexModel(ICustomer customerRep)
        {
            this.customerRep = customerRep;
        }

        public IList<Customer> Customer { get; set; } = default!;
        public async Task OnGetAsync()
        {
            Customer = customerRep.GetAll().Where(c => c.Role == "User").ToList();
        }
    }
}

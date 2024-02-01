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
    public class DeleteModel : PageModel
    {
        private readonly ICustomer customerRep;

        public DeleteModel(ICustomer customerRep)
        {
            this.customerRep = customerRep;
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = customerRep.GetById(id.Value);

            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                Customer = customer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = customerRep.GetById(id.Value);
            if (customer != null)
            {
                Customer = customer;
                customerRep.Delete(Customer);
            }

            return RedirectToPage("./Index");
        }
    }
}

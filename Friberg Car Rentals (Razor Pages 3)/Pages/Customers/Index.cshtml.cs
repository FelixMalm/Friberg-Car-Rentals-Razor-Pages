using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Friberg_Car_Rentals__Razor_Pages_.Data;
using Friberg_Car_Rentals__Razor_Pages_3_.Data;

namespace Friberg_Car_Rentals__Razor_Pages_3_.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly Friberg_Car_Rentals__Razor_Pages_3_.Data.Friberg_Car_Rentals__Razor_Pages_3_Context _context;

        public IndexModel(Friberg_Car_Rentals__Razor_Pages_3_.Data.Friberg_Car_Rentals__Razor_Pages_3_Context context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Customer = await _context.Customer.ToListAsync();
        }
    }
}

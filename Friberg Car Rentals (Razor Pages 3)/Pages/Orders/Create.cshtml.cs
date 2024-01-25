using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Friberg_Car_Rentals__Razor_Pages_.Data;
using Friberg_Car_Rentals__Razor_Pages_3_.Data;

namespace Friberg_Car_Rentals__Razor_Pages_3_.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly Friberg_Car_Rentals__Razor_Pages_3_.Data.Friberg_Car_Rentals__Razor_Pages_3_Context _context;

        public CreateModel(Friberg_Car_Rentals__Razor_Pages_3_.Data.Friberg_Car_Rentals__Razor_Pages_3_Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Order.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

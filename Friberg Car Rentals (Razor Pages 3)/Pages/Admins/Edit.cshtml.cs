using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Friberg_Car_Rentals__Razor_Pages_.Data;
using Friberg_Car_Rentals__Razor_Pages_3_.Data;
using Friberg_Car_Rentals__Razor_Pages_3_.Repository;

namespace Friberg_Car_Rentals__Razor_Pages_3_.Pages.Admins
{
    public class EditModel : PageModel
    {
        private readonly IAdmin adminRep;

        public EditModel(IAdmin adminRep)
        {
            this.adminRep = adminRep;
        }

        [BindProperty]
        public Admin Admin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = adminRep.GetById(id.Value);
            if (admin == null)
            {
                return NotFound();
            }
            Admin = admin;
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                adminRep.Update(Admin);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExist(Admin.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AdminExist(int id)
        {
            return adminRep.AdminExist(id);
        }
    }
}

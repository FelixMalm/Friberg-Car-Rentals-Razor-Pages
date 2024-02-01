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

namespace Friberg_Car_Rentals__Razor_Pages_3_.Pages.Admins
{
    public class IndexModel : PageModel
    {
        private readonly IAdmin adminRep;

        public IndexModel(IAdmin adminRep)
        {
            this.adminRep = adminRep;
        }

        public IList<Admin> Admin { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Admin = adminRep.GetAll().ToList<Admin>();
        }
    }
}

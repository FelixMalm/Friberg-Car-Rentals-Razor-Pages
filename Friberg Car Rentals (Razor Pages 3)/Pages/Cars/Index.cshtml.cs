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
using NuGet.Protocol.Core.Types;

namespace Friberg_Car_Rentals__Razor_Pages_3_.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly ICar carRep;
        
        public IndexModel(ICar carRep)
        {
            this.carRep = carRep;
        }

        public IList<Car> Car { get; set; } = default!;
        public async Task OnGetAsync()
        {
            Car = carRep.GetAll().ToList<Car>();
        }

        public IActionResult OnPostPlaceOrder(int carId)
        {
            if (HttpContext.Session.GetString("CustomerId") == null)
            {
                return RedirectToPage("/Account/Login");
            }

            int customerId = int.Parse(HttpContext.Session.GetString("CustomerId"));

            return RedirectToPage("/Orders/Create", new { carId = carId, customerId = customerId });
        }
    }
}

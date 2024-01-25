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
        /*private readonly Friberg_Car_Rentals__Razor_Pages_3_.Data.Friberg_Car_Rentals__Razor_Pages_3_Context _context;

        public IndexModel(Friberg_Car_Rentals__Razor_Pages_3_.Data.Friberg_Car_Rentals__Razor_Pages_3_Context context)
        {
            _context = context;
        }

        public IList<Car> Car { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Car = await _context.Car.ToListAsync();
        }*/

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

        /*public void OnGet()
        {
            Car = carRep.GetAll();
        }*/

        /*public async Task OnGetAsync()
        {
            Car = (await carRep.Car.GetAllAsync()).ToList();
        }*/
    }
}

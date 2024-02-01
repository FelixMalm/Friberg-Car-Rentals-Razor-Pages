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

namespace Friberg_Car_Rentals__Razor_Pages_3_.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly IOrder orderRep;

        public IndexModel(IOrder orderRep)
        {
            this.orderRep = orderRep;
        }

        public IList<Order> Orders { get;set; } = default!;

        public void OnGet()
        {
            Orders = orderRep.GetAll().ToList();
        }
    }
}

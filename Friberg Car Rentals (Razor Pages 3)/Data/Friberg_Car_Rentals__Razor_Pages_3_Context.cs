using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Friberg_Car_Rentals__Razor_Pages_.Data;

namespace Friberg_Car_Rentals__Razor_Pages_3_.Data
{
    public class Friberg_Car_Rentals__Razor_Pages_3_Context : DbContext
    {
        public Friberg_Car_Rentals__Razor_Pages_3_Context (DbContextOptions<Friberg_Car_Rentals__Razor_Pages_3_Context> options)
            : base(options)
        {
        }

        public DbSet<Friberg_Car_Rentals__Razor_Pages_.Data.Car> Car { get; set; } = default!;
        public DbSet<Friberg_Car_Rentals__Razor_Pages_.Data.Customer> Customer { get; set; } = default!;
        public DbSet<Friberg_Car_Rentals__Razor_Pages_.Data.Admin> Admin { get; set; } = default!;
        public DbSet<Friberg_Car_Rentals__Razor_Pages_.Data.Order> Order { get; set; } = default!;
    }
}

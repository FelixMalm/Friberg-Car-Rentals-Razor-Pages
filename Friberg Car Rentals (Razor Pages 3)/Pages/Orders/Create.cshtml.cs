using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Friberg_Car_Rentals__Razor_Pages_.Data;
using Friberg_Car_Rentals__Razor_Pages_3_.Data;
using Friberg_Car_Rentals__Razor_Pages_3_.Repository;
using Microsoft.EntityFrameworkCore;

namespace Friberg_Car_Rentals__Razor_Pages_3_.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly IOrder orderRep;
        private readonly ICar carRep;
        private readonly ICustomer customerRep;

        [BindProperty]
        public Order Order { get; set; }
        public SelectList CarOptions { get; set; }
        public SelectList CustomerOptions { get; set; }

        public CreateModel(IOrder orderRep, ICar carRep, ICustomer customerRep)
        {
            this.orderRep = orderRep;
            this.carRep = carRep;
            this.customerRep = customerRep;
        }

        public void OnGet()
        {
            var cars = carRep.GetAll().ToList();
            CarOptions = new SelectList(cars, "Id", "Model" , "Price");

            var customers = customerRep.GetAll().ToList();
            CustomerOptions = new SelectList(customers, "Id", "FirstName", "LastName");
        }

        public IActionResult OnPost()
        {
            try
            {
                Order.Customer = customerRep.GetById(Order.Customer.Id);
                Order.Car = carRep.GetById(Order.Car.Id);
            }
            catch (Exception ex)
            {

            }

            orderRep.Add(Order);

            return RedirectToPage("./Index");
        }
    }
}

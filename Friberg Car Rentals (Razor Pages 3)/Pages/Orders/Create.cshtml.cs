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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICustomer customerRep;

        [BindProperty]
        public Order Order { get; set; }
        public SelectList CarOptions { get; set; }
        public SelectList CustomerOptions { get; set; }

        public CreateModel(IOrder orderRep, ICar carRep, ICustomer customerRep, IHttpContextAccessor httpContextAccessor)
        {
            this.orderRep = orderRep;
            this.carRep = carRep;
            this.customerRep = customerRep;
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnGet()
        {
            var cars = carRep.GetAll().ToList();
            CarOptions = new SelectList(cars, "Id", "Model" , "Price");

            //var customers = customerRep.GetAll().Where(c => c.Role != "Admin").ToList();
            //CustomerOptions = new SelectList(customers, "Id", "FirstName", "LastName");
        }

        public IActionResult OnPost()
        {
            try
            {
                string rentalStartDateString = Request.Form["rentalStartDate"];
                string rentalEndDateString = Request.Form["rentalEndDate"];

                DateTime.TryParse(rentalStartDateString, out DateTime rentalStartDate);
                DateTime.TryParse(rentalEndDateString, out DateTime rentalEndDate);

                var customerIdString = _httpContextAccessor.HttpContext.Session.GetString("CustomerId");
                int customerId = int.Parse(customerIdString);

                Order.Customer = customerRep.GetById(customerId);
                Order.Car = carRep.GetById(Order.Car.Id);
                Order.RentalStartDate = rentalStartDate;
                Order.RentalEndDate = rentalEndDate;

                if (!orderRep.IsCarAvailableForOrder(Order.Car.Id, Order.RentalStartDate, Order.RentalEndDate))
                {
                    ModelState.AddModelError(string.Empty, "The selected car is not available for the specified rental period.");
                    ModelState.AddModelError(string.Empty, "Go back to list to make a new order. ");
                    return RedirectToPage("./Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                return Page();
            }

            orderRep.Add(Order);

            return RedirectToPage("./Index");
        }
    }
}

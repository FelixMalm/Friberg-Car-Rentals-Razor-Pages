using Friberg_Car_Rentals__Razor_Pages_.Data;
using Friberg_Car_Rentals__Razor_Pages_3_.Data;
using Microsoft.EntityFrameworkCore;

namespace Friberg_Car_Rentals__Razor_Pages_3_.Repository
{
    public class OrderRepository : IOrder
    {
        private readonly Friberg_Car_Rentals__Razor_Pages_3_Context applicationDbContext;

        public OrderRepository(Friberg_Car_Rentals__Razor_Pages_3_Context applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        //public List<Order> Orders { get; set; }
        public void Add(Order order)
        {
            applicationDbContext.Order.Add(order);
            applicationDbContext.SaveChanges();
        }

        public bool OrderExists(int id)
        {
            return applicationDbContext.Car.Any(car => car.Id == id);
        }

        public void Delete(Order order)
        {
            applicationDbContext.Remove(order);
            applicationDbContext.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            return applicationDbContext.Order
                .Include(o => o.Car)
                .Include(o => o.Customer)
                .OrderBy(o => o.Id)
                .ToList();
        }

        public Order GetById(int id)
        {
            return applicationDbContext.Order.FirstOrDefault(s => s.Id == id);
        }

        public void Update(Order order)
        {
            applicationDbContext.Update(order);
            applicationDbContext.SaveChanges();
        }

        public List<Order> GetOrders()
        {
            return applicationDbContext.Order.ToList();
        }

        public void AddOrder(Order order)
        {
            applicationDbContext.Order.Add(order);
            applicationDbContext.SaveChanges();
        }
    }
}

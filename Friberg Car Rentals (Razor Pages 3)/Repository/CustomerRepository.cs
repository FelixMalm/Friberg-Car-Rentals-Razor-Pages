using Friberg_Car_Rentals__Razor_Pages_.Data;
using Friberg_Car_Rentals__Razor_Pages_3_.Data;
using Microsoft.EntityFrameworkCore;

namespace Friberg_Car_Rentals__Razor_Pages_3_.Repository
{
    public class CustomerRepository : ICustomer
    {
        private readonly Friberg_Car_Rentals__Razor_Pages_3_Context applicationDbContext;

        public CustomerRepository(Friberg_Car_Rentals__Razor_Pages_3_Context applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public void Add(Customer customer)
        {
            applicationDbContext.Add(customer);
            applicationDbContext.SaveChanges();
        }

        public bool CustomerExists(int id)
        {
            return applicationDbContext.Customer.Any(customer => customer.Id == id);
        }

        public void Delete(Customer customer)
        {
            applicationDbContext.Remove(customer);
            applicationDbContext.SaveChanges();
        }

        public IEnumerable<Customer> GetAll()
        {
            return applicationDbContext.Customer.OrderBy(x => x.LastName);
        }

        public Customer GetById(int id)
        {
            return applicationDbContext.Customer.FirstOrDefault(s => s.Id == id);
        }

        public void Update(Customer customer)
        {
            applicationDbContext.Update(customer);
            applicationDbContext.SaveChanges();
        }

        public Customer GetCustomerByUsername(string username)
        {
            return applicationDbContext.Customer.FirstOrDefault(c => c.Username == username);
        }
    }
}

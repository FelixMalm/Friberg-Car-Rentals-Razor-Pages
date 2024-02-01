using Friberg_Car_Rentals__Razor_Pages_.Data;

namespace Friberg_Car_Rentals__Razor_Pages_3_.Repository
{
    public interface ICustomer
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
        bool CustomerExists(int id);
    }
}

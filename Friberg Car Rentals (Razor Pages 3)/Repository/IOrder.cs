using Friberg_Car_Rentals__Razor_Pages_.Data;

namespace Friberg_Car_Rentals__Razor_Pages_3_.Repository
{
    public interface IOrder
    {
        IEnumerable<Order> GetAll();
        Order GetById(int id);
        void Add(Order order);
        void Update(Order order);
        void Delete(Order order);
        bool OrderExists(int id);
        List<Order> GetOrders();
        void AddOrder(Order order);
        bool IsCarAvailableForOrder(int carId, DateTime rentalStartDate, DateTime rentalEndDate);
    }
}

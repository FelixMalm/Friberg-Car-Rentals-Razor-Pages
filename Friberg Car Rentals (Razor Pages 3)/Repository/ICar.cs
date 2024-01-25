using Friberg_Car_Rentals__Razor_Pages_.Data;

namespace Friberg_Car_Rentals__Razor_Pages_3_.Repository
{
    public interface ICar
    {
        //IList<Car> GetAll();
        IEnumerable<Car> GetAll();
        Car GetById(int id);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}

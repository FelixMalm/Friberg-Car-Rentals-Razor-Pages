using Friberg_Car_Rentals__Razor_Pages_.Data;
using Friberg_Car_Rentals__Razor_Pages_3_.Data;
using Microsoft.EntityFrameworkCore;

namespace Friberg_Car_Rentals__Razor_Pages_3_.Repository
{
    public class CarRepository : ICar
    {
        private readonly Friberg_Car_Rentals__Razor_Pages_3_Context applicationDbContext;

        public CarRepository(Friberg_Car_Rentals__Razor_Pages_3_Context applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void Add(Car car)
        {
            applicationDbContext.Add(car);
            applicationDbContext.SaveChanges();
        }

        public void Delete(Car car)
        {
            applicationDbContext.Remove(car);
            applicationDbContext.SaveChanges();
        }

        /*public IList<Car> GetAll()
        {
            return applicationDbContext.Car.OrderBy(x => x.Model).ToList();
        }*/

        public IEnumerable<Car> GetAll()
        {
            return applicationDbContext.Car.OrderBy(x => x.Model);
        }

        public Car GetById(int id)
        {
            return applicationDbContext.Car.FirstOrDefault(s => s.Id == id);
        }

        public void Update(Car car)
        {
            applicationDbContext.Update(car);
            applicationDbContext.SaveChanges();
        }

        /*public async override Task<IEnumerable<Car>> GetAllAsync()
        {
            return await applicationDbContext.Car.ToListAsync();
        }*/
    }
}

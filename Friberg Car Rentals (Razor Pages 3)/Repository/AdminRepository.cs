using Friberg_Car_Rentals__Razor_Pages_.Data;
using Friberg_Car_Rentals__Razor_Pages_3_.Data;

namespace Friberg_Car_Rentals__Razor_Pages_3_.Repository
{
    public class AdminRepository : IAdmin
    {
        private readonly Friberg_Car_Rentals__Razor_Pages_3_Context applicationDbContext;

        public AdminRepository(Friberg_Car_Rentals__Razor_Pages_3_Context applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public void Add(Admin admin)
        {
            applicationDbContext.Add(admin);
            applicationDbContext.SaveChanges();
        }

        public bool AdminExist(int id)
        {
            return applicationDbContext.Customer.Any(admin => admin.Id == id);
        }

        public void Delete(Admin admin)
        {
            applicationDbContext.Remove(admin);
            applicationDbContext.SaveChanges();
        }

        public IEnumerable<Admin> GetAll()
        {
            return applicationDbContext.Admin.OrderBy(x => x.LastName);
        }

        public Admin GetById(int id)
        {
            return applicationDbContext.Admin.FirstOrDefault(s => s.Id == id);
        }

        public void Update(Admin admin)
        {
            applicationDbContext.Update(admin);
            applicationDbContext.SaveChanges();
        }
    }
}

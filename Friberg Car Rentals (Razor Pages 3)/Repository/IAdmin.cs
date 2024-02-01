using Friberg_Car_Rentals__Razor_Pages_.Data;

namespace Friberg_Car_Rentals__Razor_Pages_3_.Repository
{
    public interface IAdmin
    {
        IEnumerable<Admin> GetAll();
        Admin GetById(int id);
        void Add(Admin admin);
        void Update(Admin admin);
        void Delete(Admin admin);
        bool AdminExist(int id);
    }
}

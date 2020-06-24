using Project.Model;

namespace Project.Repositories.Abstract
{
    public interface IMedicineRepository : IRepository<Medicine, long>
    {
        Medicine GetByName(string name);
        Medicine RegisterMedicine(string name, string purpose, string administration, string type, string description);
    }

}
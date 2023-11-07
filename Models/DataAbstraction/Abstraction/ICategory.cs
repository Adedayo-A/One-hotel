using HotelPremium.Models.Poco_Classes;

namespace HotelPremium.Models.DataAbstraction.Abstraction
{
    public interface ICategory
    {
        IEnumerable<Category> GetAll { get; }

        Category GetCategory(int id);

    }
}

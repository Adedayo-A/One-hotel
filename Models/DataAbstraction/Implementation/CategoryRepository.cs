using HotelPremium.Models.DataAbstraction.Abstraction;
using HotelPremium.Models.Poco_Classes;

namespace HotelPremium.Models.DataAbstraction.Implementation
{
    public class CategoryRepository : ICategory
    {
        public IEnumerable<Category> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}

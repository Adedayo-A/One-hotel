using HotelPremium.Models.DataAbstraction.Abstraction;
using HotelPremium.Models.Poco_Classes;

namespace HotelPremium.Models.DataAbstraction.Implementation.EFCore
{
    public class EFCategoryRepository : ICategory
    {
        public readonly HotelContext _context;

        public EFCategoryRepository(HotelContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAll => _context.Categories;

        public Category? GetCategory(int id)
        {
            Category category = _context.Categories.Find(id);

            return category;
        }

        public async Task<Category?> GetCategoryAsync(int id)
        {
            Category category = await _context.Categories.FindAsync(id);

            return category;
        }
    }
}

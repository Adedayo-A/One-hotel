using HotelPremium.Helpers;
using HotelPremium.Models.DataAbstraction.Abstraction;
using HotelPremium.Models.Poco_Classes;

namespace HotelPremium.Models.DataAbstraction.Implementation.FileImplementation
{
    public class CategoryRepository : ICategory
    {
        private static string DirectoryPath = Path.Combine(Environment.CurrentDirectory, "HotelPremium");
        private string FilePath = Path.Combine(DirectoryPath, "categories.json");
        public IEnumerable<Category> GetAll
        {
            get
            {
                var categories = FileOperations.ReadFiles<Category>(FilePath);

                return categories;
            }
        }

        public Category GetCategory(int id)
        {
            return GetAll.FirstOrDefault(cat => cat.CategoryId == id);
        }

        public void Update(int id, Category newCategory)
        {
            var category = GetAll.Where(c => c.CategoryId == id).FirstOrDefault();

            category.Name = newCategory.Name;
            category.Description = newCategory.Description;
        }

    }
}

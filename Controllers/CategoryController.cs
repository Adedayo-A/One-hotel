using HotelPremium.Models.DataAbstraction.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace HotelPremium.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory _Category;

        public CategoryController(ICategory category)
        {
            _Category = category;
        }

        public IActionResult Index()
        {
            var categories = _Category.GetAll;

            return View(categories);
        }
    }
}

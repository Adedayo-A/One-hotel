using HotelPremium.Models.DataAbstraction.Abstraction;
using HotelPremium.Models.Poco_Classes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelPremium.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IUserFavoriteHotelsRepo _userFavoriteHotelsRepo;

        public HomeController(IHotelRepository hotelRepository, IUserFavoriteHotelsRepo userFavoriteHotelsRepo)
        {
            _hotelRepository = hotelRepository;
            _userFavoriteHotelsRepo = userFavoriteHotelsRepo;
        }

        public IActionResult Index()
        {
            var hotelsOfTheMonth = _userFavoriteHotelsRepo.GetHotelsOfTheMonth();

            //HotelVM hotelsMonthVM = new HotelVM
            //{
            //    Hotels = hotelsOfTheMonth
            //};

            return View(hotelsOfTheMonth);
        }
    }
}

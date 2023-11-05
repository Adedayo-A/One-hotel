using HotelPremium.Models.DataAbstraction.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace HotelPremium.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public IActionResult Hotels() 
        {
            var hotels = _hotelRepository.Hotels;
            return View(hotels);
        }

        [HttpGet()]
        public IActionResult GetOne(int hotelid)
        {
            var hotel = _hotelRepository.Get(hotelid);
            if(hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        public IActionResult Contact() 
        {
            return View();
        }
    }
}

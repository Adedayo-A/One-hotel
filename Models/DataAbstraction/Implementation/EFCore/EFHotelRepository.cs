using HotelPremium.Models.DataAbstraction.Abstraction;
using HotelPremium.Models.Poco_Classes;
using Microsoft.EntityFrameworkCore;

namespace HotelPremium.Models.DataAbstraction.Implementation.EFCore
{
    public class EFHotelRepository : IHotelRepository, IUserFavoriteHotelsRepo
    {
        private readonly HotelContext _context;

        public EFHotelRepository(HotelContext context)
        {
            _context= context;
        }

        public IEnumerable<Hotel> Hotels => _context.Hotels.Include(h => h.Category);

        public Hotel Get(int id)
        {
            Hotel? hotel = _context.Hotels.FirstOrDefault(hotel => hotel.HotelId == id);

            return hotel;
        }

        public async Task<Hotel> GetAsync(int id)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(hotel => hotel.HotelId==id);

            return hotel;
        }

        public IEnumerable<Hotel> GetHotelsOfTheMonth()
        {
            var hotels = _context.Hotels.Where(h => h.HotelOfTheMonth).Include(h => h.Category);
            
            hotels.Order();

            return hotels;
        }
    }

    public class PickSomePropertiesFromHotelModel
    {
        public int theId { get; set; }
        public string theName { get; set; }
        public decimal thePrice { get; set; }
        public string thePricePerRoom { get; set; }
        public bool isHotelOfTheMonth { get; set; }
    }
}

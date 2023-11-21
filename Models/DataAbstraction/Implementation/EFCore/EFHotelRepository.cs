using HotelPremium.Models.DataAbstraction.Abstraction;
using HotelPremium.Models.Poco_Classes;
using Microsoft.EntityFrameworkCore;

namespace HotelPremium.Models.DataAbstraction.Implementation.EFCore
{
    public class EFHotelRepository : IHotelRepository
    {
        private readonly HotelContext _context;

        public EFHotelRepository(HotelContext context)
        {
            _context= context;
        }

        public IEnumerable<Hotel> Hotels => _context.Hotels;

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
    }
}

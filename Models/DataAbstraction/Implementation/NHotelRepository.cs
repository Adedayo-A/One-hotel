using HotelPremium.Models.DataAbstraction.Abstraction;
using HotelPremium.Models.Poco_Classes;

namespace HotelPremium.Models.DataAbstraction.Implementation
{
    public class NHotelRepository : IHotelRepository, IUserFavoriteHotelsRepo
    {
        public IEnumerable<Hotel> Hotels => throw new NotImplementedException();

        public Hotel Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Hotel> GetHotelsOfTheMonth()
        {
            throw new NotImplementedException();
        }

        public void SeedHotels()
        {
            throw new NotImplementedException();
        }
    }
}

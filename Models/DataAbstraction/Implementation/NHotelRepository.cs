using HotelPremium.Models.DataAbstraction.Abstraction;
using HotelPremium.Models.Poco_Classes;

namespace HotelPremium.Models.DataAbstraction.Implementation
{
    public class NHotelRepository : IHotelRepository, IUserFavoriteHotelsRepo
    {
        public IEnumerable<HotelVM> Hotels => throw new NotImplementedException();

        public HotelVM Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HotelVM> GetHotelsOfTheMonth()
        {
            throw new NotImplementedException();
        }

        public void SeedHotels()
        {
            throw new NotImplementedException();
        }
    }
}

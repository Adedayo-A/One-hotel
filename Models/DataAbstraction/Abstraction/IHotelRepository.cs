using HotelPremium.Models.Poco_Classes;

namespace HotelPremium.Models.DataAbstraction.Abstraction
{
    public interface IHotelRepository
    {
        public IEnumerable<Hotel> GetAll();
        public Hotel Get(int id);
    }
}

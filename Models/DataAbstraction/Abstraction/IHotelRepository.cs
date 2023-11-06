using HotelPremium.Models.Poco_Classes;

namespace HotelPremium.Models.DataAbstraction.Abstraction
{
    public interface IHotelRepository
    {
        public IEnumerable<HotelVM> Hotels { get; }
        public HotelVM Get(int id);
    }
}

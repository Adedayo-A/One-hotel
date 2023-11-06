using HotelPremium.Models.Poco_Classes;

namespace HotelPremium.Models.DataAbstraction.Abstraction
{
    public interface IUserFavoriteHotelsRepo
    {
        IEnumerable<HotelVM> GetHotelsOfTheMonth();
    }
}

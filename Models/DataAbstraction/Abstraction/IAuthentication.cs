using HotelPremium.Models.Poco_Classes;

namespace HotelPremium.Models.DataAbstraction.Abstraction
{
    public interface IAuthentication
    {
        User Login(string email, string password);

        bool Signup(User user);
    }
}

using HotelPremium.Models.Poco_Classes;

namespace HotelPremium.Models.DataAbstraction.Abstraction
{
    public interface IAuthentication
    {
        User Login(string email, string password);

        void Signup(User user);

        User? GetUser(string email);

        IEnumerable<User> Users { get; }
        
    }
}

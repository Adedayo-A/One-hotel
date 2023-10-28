using HotelPremium.Models.DataAbstraction.Abstraction;
using HotelPremium.Models.Poco_Classes;

namespace HotelPremium.Models.DataAbstraction.Implementation
{
    public class UserRepository : IAuthentication
    {
        private List<User> _users;

        private static string DirectoryPath = Path.Combine(Environment.CurrentDirectory, "HotelPremium");
        private string FilePath = Path.Combine(DirectoryPath, "users.json");

        public User Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool Signup(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Users 
        { 
            private get 
            { 
                if(!File.Exists(FilePath))
                {
                    if(!Directory.Exists(DirectoryPath))
                    {
                        Directory.CreateDirectory(DirectoryPath);
                    }
                    
                }
               throw new NotImplementedException(); 
            } 
        }
    }
}

using HotelPremium.Helpers;
using HotelPremium.Models.DataAbstraction.Abstraction;
using HotelPremium.Models.Poco_Classes;

namespace HotelPremium.Models.DataAbstraction.Implementation.FileImplementation
{
    public class UserRepository : IAuthentication
    {
        public static List<User> _users { get; private set; } = new List<User>();
        public static Queue<User> _usersQ { get; private set; } = new Queue<User>();


        private static string DirectoryPath = Path.Combine(Environment.CurrentDirectory, "HotelPremium");
        private string FilePath = Path.Combine(DirectoryPath, "users.json");

        public User? Login(string email, string password)
        {
            _users = Users.ToList();

            if (_users.Count == null)
            {
                return null;
            }

            password = PasswordHash.HashPassword(password);

            User? user = Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            return user;
        }

        public void Signup(User user)
        {
            user.Password = PasswordHash.HashPassword(user.Password);
            _users = Users.ToList();
            _users.Add(user);

            fileOp(_users);
        }

        public IEnumerable<User> Users
        {
            get
            {
                if (!File.Exists(FilePath))
                {
                    if (!Directory.Exists(DirectoryPath))
                    {
                        Directory.CreateDirectory(DirectoryPath);
                    }
                }
                _users = FileOperations.ReadFiles<User>(FilePath);

                return _users;
            }
        }

        private void fileOp(object obj)
        {
            if (!File.Exists(FilePath))
            {
                if (!Directory.Exists(DirectoryPath))
                {
                    Directory.CreateDirectory(DirectoryPath);
                }
                FileOperations.PrettyWrite(obj, FilePath);
            }
            else
            {
                FileOperations.PrettyWrite(obj, FilePath);
            }

        }

        public User? GetUser(string email)
        {
            User? user = _users.FirstOrDefault(u => u.Email == email);

            return user;
        }

        public User? GetNewuser()
        {
            throw new NotImplementedException($"{nameof(GetNewuser)} is not implemented");
        }
    }
}

namespace HotelPremium.Models.Poco_Classes
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; }
    }
}

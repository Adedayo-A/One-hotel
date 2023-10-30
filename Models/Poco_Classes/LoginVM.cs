using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HotelPremium.Models.Poco_Classes
{
    public class LoginVM
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

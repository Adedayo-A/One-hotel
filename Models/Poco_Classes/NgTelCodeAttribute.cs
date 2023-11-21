using System.ComponentModel.DataAnnotations;

namespace HotelPremium.Models.Poco_Classes
{
    internal class NgTelCodeAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            bool isNG = value.ToString().StartsWith("+234") ? true : false;

            return isNG;
        }
    }
}
using System.ComponentModel.DataAnnotations;

namespace HotelPremium.Models.Poco_Classes
{
    public class RegistrationVM
    {
        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
    ErrorMessage = "The email address is not entered in a correct format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please provide a password")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Please confirm your password")]
        public string ConfirmPassword { get; set; }
        
        [Required(ErrorMessage = "Phone number cannot be null")]
        [NgTelCode(ErrorMessage = "Number must be in Nigeria tel code - +234")]
        public string Phone { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Exceeded Limit")]
        [Required(ErrorMessage = $"{nameof(LastName)} is required" )]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int MyProperty { get; set; }
    }
}

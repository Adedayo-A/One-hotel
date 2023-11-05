using HotelPremium.Models.DataAbstraction.Abstraction;
using HotelPremium.Models.Poco_Classes;
using Microsoft.AspNetCore.Mvc;

namespace HotelPremium.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthentication _authentication;
        private readonly ICategory _category;

        public UserController(IAuthentication authentication, ICategory category)
        {
            _authentication = authentication;
            _category = category;
        }
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(RegistrationVM registrationDetails)
        {
            if(ModelState.IsValid)
            {
                if(registrationDetails.Password != registrationDetails.ConfirmPassword)
                {
                    ModelState.AddModelError(nameof(RegistrationVM.ConfirmPassword), "Password does not match");
                    return View(registrationDetails);
                }

                var userFound = _authentication.GetUser(registrationDetails.Email);
                if(userFound != null)
                {
                    ModelState.AddModelError(nameof(RegistrationVM.Email), "User already exist");

                    return View(registrationDetails);
                }

                var user = new User()
                {
                    FirstName = registrationDetails.FirstName,
                    LastName = registrationDetails.LastName,
                    Email = registrationDetails.Email,
                    Password = registrationDetails.Password,
                    Address = registrationDetails.Address,
                    Phone = registrationDetails.Phone
                };

                _authentication.Signup(user);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var user = _authentication.Login(email, password);
                if(user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                return NotFound("Invalid details");
            }
            return View();
        }
    }
}

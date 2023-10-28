using HotelPremium.Models.DataAbstraction.Abstraction;
using HotelPremium.Models.Poco_Classes;

namespace HotelPremium.Models.DataAbstraction.Implementation
{
    public class HotelRepository : IHotelRepository, IUserFavoriteHotelsRepo
    {
        private readonly IEnumerable<Hotel> hotels = new List<Hotel>
        {
            new Hotel { HotelId = 1, Address = "Lisbon, Portugal", AveragePricePerRoom = 50M,
            HotelOfTheMonth = true, isFullyBooked = false, ImageUrl = "",
                LongDescription = "A serene environment with beaches and Balcony Sky view",
                ShortDescription = "Very appealing", Name = "Benchmark", CategoryId = 1
            },
            new Hotel { HotelId = 2, Address = "Paris, France", AveragePricePerRoom = 60M,
            HotelOfTheMonth = true, isFullyBooked = false, ImageUrl = "",
                LongDescription = "A serene environment with beaches and Balcony Sky view",
                ShortDescription = "Very appealing", Name = "ParisOne", CategoryId = 1
            },
            new Hotel { HotelId = 3, Address = "Lagos, Nigeria", AveragePricePerRoom = 55M,
            HotelOfTheMonth = true, isFullyBooked = false, ImageUrl = "",
                LongDescription = "A serene environment with a nice view of the commercial Lagos",
                ShortDescription = "Highy rated", Name = "Sheraton", CategoryId = 1
            },
            new Hotel { HotelId = 4, Address = "Seychelles", AveragePricePerRoom = 30M,
            HotelOfTheMonth = false, isFullyBooked = true, ImageUrl = "",
                LongDescription = "A serene environment with beaches and Balcony Sky view",
                ShortDescription = "Very appealing", Name = "FamilyPlus", CategoryId = 2
            },
            new Hotel { HotelId = 5, Address = "Mexico", AveragePricePerRoom = 20M,
            HotelOfTheMonth = false, isFullyBooked = false, ImageUrl = "",
                LongDescription = "A serene environment with beaches and Balcony Sky view",
                ShortDescription = "Very appealing", Name = "Homely", CategoryId = 3
            }
        };
        
        public Hotel? Get(int id)
        {
            Hotel? hotel = hotels.FirstOrDefault(hotel => hotel.HotelId == id);
            return hotel;
        }

        public IEnumerable<Hotel> GetAll()
        {
            return hotels;
        }

        public IEnumerable<Hotel> GetHotelsOfTheMonth()
        {
            return hotels.Where(hotel => hotel.HotelOfTheMonth);
        }
    }
}

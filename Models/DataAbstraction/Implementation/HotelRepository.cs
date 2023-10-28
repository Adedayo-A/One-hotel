using HotelPremium.Helpers;
using HotelPremium.Models.DataAbstraction.Abstraction;
using HotelPremium.Models.Poco_Classes;

namespace HotelPremium.Models.DataAbstraction.Implementation
{
    public class HotelRepository : IHotelRepository, IUserFavoriteHotelsRepo
    {
        private readonly IEnumerable<Hotel> seedData = new List<Hotel>
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

        public static IEnumerable<Hotel> Hotels { get; private set; }

        private static string DirectoryPath = Path.Combine(Environment.CurrentDirectory, "HotelPremium");
        private string FilePath = Path.Combine(DirectoryPath, "hotels.json");
        
        public Hotel? Get(int id)
        {
            string idString = id.ToString();
            Hotel? hotel = FileOperations.ReadOne<Hotel>(FilePath, idString);
            //Hotel? hotel = Hotels.FirstOrDefault(hotel => hotel.HotelId == id);

            return hotel;
        }

        public IEnumerable<Hotel> GetAll()
        {
            return Hotels;
        }

        public IEnumerable<Hotel> GetHotelsOfTheMonth()
        {
            return Hotels.Where(hotel => hotel.HotelOfTheMonth);
        }

        public void SeedHotels()
        {
            if(!File.Exists(FilePath))
            {
                if(!Directory.Exists(DirectoryPath))
                {
                    Directory.CreateDirectory(DirectoryPath);
                }

                FileOperations.PrettyWrite(seedData, FilePath);
            }

            Hotels = FileOperations.ReadFiles<Hotel>(FilePath);
        }
    }
}

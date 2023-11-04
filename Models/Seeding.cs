using HotelPremium.Helpers;
using HotelPremium.Models.DataAbstraction.Implementation;
using HotelPremium.Models.Poco_Classes;

namespace HotelPremium.Models
{
    public static class Seeding
    {
        public static CategoryRepository _catRepo = new CategoryRepository(); 
        

        private static string DirectoryPath = Path.Combine(Environment.CurrentDirectory, "HotelPremium");
        private static string HotelPath = Path.Combine(DirectoryPath, "hotels.json");
        private static string CategoryPath = Path.Combine(DirectoryPath, "categories.json");

        private static readonly IEnumerable<Hotel> seedHotels = new List<Hotel>
        {
            new Hotel { HotelId = 1, Address = "Lisbon, Portugal", AveragePricePerRoom = 50M,
            HotelOfTheMonth = true, isFullyBooked = false,
                ImageUrl = "https://res.cloudinary.com/ddf91r8gu/image/upload/v1698221376/download3.jpg",
                LongDescription = "A serene environment with beaches and Balcony Sky view",
                ShortDescription = "Very appealing", Name = "Benchmark", CategoryId = 1,
                Category = _catRepo.GetAll.ToList()[0]
            },
            new Hotel { HotelId = 2, Address = "Paris, France", AveragePricePerRoom = 60M,
            HotelOfTheMonth = true, isFullyBooked = false, 
                ImageUrl = "https://res.cloudinary.com/ddf91r8gu/image/upload/v1698221502/download1.jpg",
                LongDescription = "A serene environment with beaches and Balcony Sky view",
                ShortDescription = "Very appealing", Name = "ParisOne", CategoryId = 2,
                Category = _catRepo.GetAll.ToList()[1]
            },
            new Hotel { HotelId = 3, Address = "Lagos, Nigeria", AveragePricePerRoom = 55M,
            HotelOfTheMonth = true, isFullyBooked = false,
                ImageUrl = "https://res.cloudinary.com/ddf91r8gu/image/upload/v1698221376/download3.jpg",
                LongDescription = "A serene environment with a nice view of the commercial Lagos",
                ShortDescription = "Highy rated", Name = "Sheraton", CategoryId = 3,
                Category = _catRepo.GetAll.ToList()[2]
            },
            new Hotel { HotelId = 4, Address = "Seychelles", AveragePricePerRoom = 30M,
            HotelOfTheMonth = false, isFullyBooked = true, 
                ImageUrl = "https://res.cloudinary.com/ddf91r8gu/image/upload/v1698221399/download2.jpg",
                LongDescription = "A serene environment with beaches and Balcony Sky view",
                ShortDescription = "Very appealing", Name = "FamilyPlus", CategoryId= 2,
                Category = _catRepo.GetAll.ToList()[1]
            },
            new Hotel { HotelId = 5, Address = "Mexico", AveragePricePerRoom = 20M,
            HotelOfTheMonth = false, isFullyBooked = false, 
                ImageUrl = "https://res.cloudinary.com/ddf91r8gu/image/upload/v1698221502/download1.jpg",
                LongDescription = "A serene environment with beaches and Balcony Sky view",
                ShortDescription = "Very appealing", Name = "Homely", CategoryId = 3,
                Category = _catRepo.GetAll.ToList()[2]
            }
        };

        private static readonly IEnumerable<Category> seedCategory = new List<Category>
        {
            new Category
            {
                CategoryId = 1, Name = "First Class",
                Description = "Hotels ranked ***** with Premium facilities",
            },
            new Category
            {
                CategoryId = 2, Name = "Second Class",
                Description = "Hotels ranked **** with Great facilities",
            },
            new Category
            {
                CategoryId = 3, Name = "Third Class",
                Description = "Hotels ranked *** with Good enough facilities",
            }
        };


        public static void SeedData() 
        {
            if (!File.Exists(HotelPath))
            {
                if (!Directory.Exists(DirectoryPath))
                {
                    Directory.CreateDirectory(DirectoryPath);
                }

                FileOperations.PrettyWrite(seedHotels, HotelPath);
            }

            if (!File.Exists(CategoryPath))
            {
                if (!Directory.Exists(DirectoryPath))
                {
                    Directory.CreateDirectory(DirectoryPath);
                }

                FileOperations.PrettyWrite(seedCategory, CategoryPath);
            }
        }
    }
}

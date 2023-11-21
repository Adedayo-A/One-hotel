using HotelPremium.Models.DataAbstraction.Implementation.EFCore;
using HotelPremium.Models.Poco_Classes;

namespace HotelPremium.Models
{
    public static class DbInitializerEF
    {
        public static void Initialize(HotelContext context)
        { 
            //HotelContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<HotelContext>();

            if (context.Hotels.Any())
            {
                return;
            }

            Category[] categories = new Category[]
            {
                new Category
                {
                    Name = "First Class",
                    Description = "Hotels ranked ***** with Premium facilities",
                },
                new Category
                {
                    Name = "Second Class",
                    Description = "Hotels ranked **** with Great facilities",
                },
                new Category
                {
                    Name = "Third Class",
                    Description = "Hotels ranked *** with Good enough facilities",
                }
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

            Hotel[] hotels = new Hotel[]
            {
                new Hotel
                {
                    Address = "Lisbon, Portugal", AveragePricePerRoom = 50M,
                    HotelOfTheMonth = true, IsFullyBooked = false,
                    ImageUrl = "https://res.cloudinary.com/ddf91r8gu/image/upload/v1698221376/download3.jpg",
                    LongDescription = "A serene environment with beaches and Balcony Sky view",
                    ShortDescription = "Very appealing", Name = "Benchmark", CategoryId = 1,
                    //Category = context.Categories.Find(1)
                },
                new Hotel
                {
                    Address = "Paris, France", AveragePricePerRoom = 60M,
                    HotelOfTheMonth = true, IsFullyBooked = false,
                    ImageUrl = "https://res.cloudinary.com/ddf91r8gu/image/upload/v1698221502/download1.jpg",
                    LongDescription = "A serene environment with beaches and Balcony Sky view",
                    ShortDescription = "Very appealing", Name = "ParisOne", CategoryId = 2,
                    //Category = context.Categories.Find(2)
                },
                new Hotel
                {
                    Address = "Lagos, Nigeria", AveragePricePerRoom = 55M,
                    HotelOfTheMonth = true, IsFullyBooked = false,
                    ImageUrl = "https://res.cloudinary.com/ddf91r8gu/image/upload/v1698221376/download3.jpg",
                    LongDescription = "A serene environment with a nice view of the commercial Lagos",
                    ShortDescription = "Highy rated", Name = "Sheraton", CategoryId = 3
                    //Category = _catRepo.GetAll.ToList()[2]
                },
                new Hotel
                {
                    Address = "Seychelles", AveragePricePerRoom = 30M,
                    HotelOfTheMonth = false, IsFullyBooked = true,
                    ImageUrl = "https://res.cloudinary.com/ddf91r8gu/image/upload/v1698221399/download2.jpg",
                    LongDescription = "A serene environment with beaches and Balcony Sky view",
                    ShortDescription = "Very appealing", Name = "FamilyPlus", CategoryId= 2
                    //Category = _catRepo.GetAll.ToList()[1]
                },
                new Hotel
                {
                    Address = "Mexico", AveragePricePerRoom = 20M,
                    HotelOfTheMonth = false, IsFullyBooked = false,
                    ImageUrl = "https://res.cloudinary.com/ddf91r8gu/image/upload/v1698221502/download1.jpg",
                    LongDescription = "A serene environment with beaches and Balcony Sky view",
                    ShortDescription = "Very appealing", Name = "Homely", CategoryId = 3
                    //Category = _catRepo.GetAll.ToList()[2]
                }
            };

            context.Hotels.AddRange(hotels);
            context.SaveChanges();
        }
    }
}

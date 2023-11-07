using HotelPremium.Helpers;
using HotelPremium.Models.DataAbstraction.Abstraction;
using HotelPremium.Models.Poco_Classes;

namespace HotelPremium.Models.DataAbstraction.Implementation.FileImplementation
{
    public class HotelRepository : IHotelRepository, IUserFavoriteHotelsRepo
    {
        public static List<Hotel> _Hotels { get; private set; }

        private static string DirectoryPath = Path.Combine(Environment.CurrentDirectory, "HotelPremium");
        private string FilePath = Path.Combine(DirectoryPath, "hotels.json");

        private readonly ICategory _Category;
        private HotelRepository(ICategory category)
        {
            _Category = category;
        }

        public Hotel Get(int id)
        {
            string idString = id.ToString();

            Hotel? hotel = Hotels.FirstOrDefault(hotel => hotel.HotelId == id);
            return hotel;
        }

        public IEnumerable<Hotel> Hotels
        {
            get
            {
                var hotels = FileOperations.ReadFiles<Hotel>(FilePath);
                return hotels;
            }
        }

        public IEnumerable<Hotel> GetHotelsOfTheMonth()
        {
            return Hotels.Where(hotel => hotel.HotelOfTheMonth);
        }
    }
}

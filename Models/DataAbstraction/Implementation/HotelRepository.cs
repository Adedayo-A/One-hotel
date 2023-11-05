using HotelPremium.Helpers;
using HotelPremium.Models.DataAbstraction.Abstraction;
using HotelPremium.Models.Poco_Classes;

namespace HotelPremium.Models.DataAbstraction.Implementation
{
    public class HotelRepository : IHotelRepository, IUserFavoriteHotelsRepo
    {
        public static IEnumerable<Hotel> _Hotels { get; private set; }

        private static string DirectoryPath = Path.Combine(Environment.CurrentDirectory, "HotelPremium");
        private string FilePath = Path.Combine(DirectoryPath, "hotels.json");
        
        public Hotel Get(int id)
        {
            string idString = id.ToString();
            //Hotel? hotel = FileOperations.ReadOne<Hotel>(FilePath, idString);
            Hotel? hotel = Hotels.FirstOrDefault(hotel => hotel.HotelId == id);

            //var category = _Category.GetAll.FirstOrDefault(cat => cat.CategoryId == _hotel.HotelId);

            //var hotel = new GetSingleHotelVM
            //{
            //    Name = _hotel.Name,
            //    Address = _hotel.Address,
            //    LongDescription = _hotel.LongDescription,
            //    ShortDescription = _hotel.ShortDescription,
            //    ImageUrl = _hotel.ImageUrl,
            //    AveragePricePerRoom = _hotel.AveragePricePerRoom,
            //    HotelId = _hotel.HotelId,
            //    isFullyBooked = _hotel.isFullyBooked,
            //    HotelOfTheMonth = _hotel.HotelOfTheMonth,
            //    CategoryName = category.Name,
            //    CategoryDescription = category.Description
            //};

            return hotel;
        }

        public IEnumerable<Hotel> Hotels
        {
            get { _Hotels = FileOperations.ReadFiles<Hotel>(FilePath);
                return _Hotels; }
        }

        public IEnumerable<Hotel> GetHotelsOfTheMonth()
        {
            return Hotels.Where(hotel => hotel.HotelOfTheMonth);
        }
    }
}

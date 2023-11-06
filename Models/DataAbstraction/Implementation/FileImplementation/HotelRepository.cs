using HotelPremium.Helpers;
using HotelPremium.Models.DataAbstraction.Abstraction;
using HotelPremium.Models.Poco_Classes;

namespace HotelPremium.Models.DataAbstraction.Implementation.FileImplementation
{
    public class HotelRepository : IHotelRepository, IUserFavoriteHotelsRepo
    {
        public static List<HotelVM> _Hotels { get; private set; }

        private static string DirectoryPath = Path.Combine(Environment.CurrentDirectory, "HotelPremium");
        private string FilePath = Path.Combine(DirectoryPath, "hotels.json");

        private readonly ICategory _Category;
        private HotelRepository(ICategory category)
        {
            _Category = category;
        }

        public HotelVM Get(int id)
        {
            string idString = id.ToString();
            //Hotel? hotel = FileOperations.ReadOne<Hotel>(FilePath, idString);
            HotelVM? hotel = Hotels.FirstOrDefault(hVM => hVM.Hotel.HotelId == id);

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

        public IEnumerable<HotelVM> Hotels
        {
            get
            {
                var hotels = FileOperations.ReadFiles<Hotel>(FilePath);

                foreach (Hotel hotel in hotels)
                {
                    var category = _Category.GetCategory(hotel.CategoryId);
                    var obj = new HotelVM()
                    {
                        Hotel = hotel,
                        Category = category
                    };

                    _Hotels.Add(obj);
                }

                return _Hotels;
            }
        }

        public IEnumerable<HotelVM> GetHotelsOfTheMonth()
        {
            return Hotels.Where(hVM => hVM.Hotel.HotelOfTheMonth);
        }
    }
}
